import mediapipe as mp
import cv2
import numpy as np
import tensorflow as tf
from tensorflow.keras.models import load_model
import random
import time

# Initialize mediapipe
mpHands = mp.solutions.hands
hands = mpHands.Hands(max_num_hands=1, min_detection_confidence=0.7)
mpDraw = mp.solutions.drawing_utils

# Load the gesture recognizer model
model = load_model('mp_hand_gesture')

f = open('gesture.names', 'r')
classNames = f.read().split('\n')
f.close()
# Initialize the webcam
cap = cv2.VideoCapture(0)

# Initialize game variables
user_choice = None
computer_choice = None
winner = None

# Function to map user's gesture to "rock," "paper," or "scissors"
def map_gesture_to_choice(gesture):
    if gesture == "rock" or gesture == "peace":
        return "scissors"
    elif gesture == "stop" or gesture == "live long":
        return "paper"
    elif gesture == "fist":
        return "rock"
    else:
        return "invalid"

# Function to get a random choice for the computer
def get_computer_choice():
    return random.choice(["rock", "paper", "scissors"])

# Function to determine the winner
def determine_winner(user, computer):
    if user == computer:
        return "It's a tie!"
    elif (user == "rock" and computer == "scissors") or \
         (user == "paper" and computer == "rock") or \
         (user == "scissors" and computer == "paper"):
        return "You win!"
    else:
        return "Computer wins!"

# Timer variables
start_time = time.time()
interval = 5  # Five seconds

while True:
    # Read each frame from the webcam
    _, frame = cap.read()

    x, y, c = frame.shape

    # Flip the frame vertically
    frame = cv2.flip(frame, 1)
    framergb = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)

    # Get hand landmark prediction
    result = hands.process(framergb)

    className = ''

    # Post-process the result
    if result.multi_hand_landmarks:
        landmarks = []
        for handslms in result.multi_hand_landmarks:
            for lm in handslms.landmark:
                lmx = int(lm.x * x)
                lmy = int(lm.y * y)
                landmarks.append([lmx, lmy])
            mpDraw.draw_landmarks(frame, handslms, mpHands.HAND_CONNECTIONS)

            # Predict gesture
            prediction = model.predict([landmarks])
            classID = np.argmax(prediction)
            className = map_gesture_to_choice(classNames[classID])
            user_choice = className

    # Check if it's time to update the computer's choice and determine the winner
    if time.time() - start_time >= interval:
        user_choice = className
        computer_choice = get_computer_choice()
        winner = determine_winner(user_choice, computer_choice)
        start_time = time.time()

    # Display user's choice, computer's choice, and winner on the frame
    cv2.putText(frame, f"You: {user_choice}", (10, 50), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2, cv2.LINE_AA)
    cv2.putText(frame, f"Computer: {computer_choice}", (10, 100), cv2.FONT_HERSHEY_SIMPLEX, 1, (255, 0, 0), 2, cv2.LINE_AA)
    cv2.putText(frame, f"Winner: {winner}", (10, 150), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 2, cv2.LINE_AA)

    # Show the final output
    cv2.imshow("Rock, Paper, Scissors", frame)


    if cv2.waitKey(1) == ord('q'):
        break

# Release the webcam and destroy all active windows
cap.release()
cv2.destroyAllWindows()
