package com.bstu.lab15;

import java.io.IOException;
import java.util.Arrays;
import java.util.Properties;
import javax.mail.*;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeBodyPart;

public class EmailAdmin {
    public static String showMessages(final String userEmail, final String password) throws MessagingException, IOException {

        String host = "imap.googlemail.com";
        Properties properties = new Properties();
        properties.put("mail.imaps.ssl.trust", "*");
        Store store = Session.getInstance(properties, new javax.mail.Authenticator() {
            protected PasswordAuthentication getPasswordAuthentication() {
                return new PasswordAuthentication(userEmail, password);
            }
        }).getStore("imaps");
        store.connect(host, userEmail, password);
        Folder folder = store.getFolder("INBOX");
        folder.open(Folder.READ_ONLY);


        StringBuilder result = new StringBuilder();
        Message[] folderMessages = folder.getMessages(folder.getMessageCount()-5,folder.getMessageCount());


        for (Message message: folderMessages) {

            result.append("<div  style='cursor: pointer;'>");
            result.append("<p>Sender:   ").append(InternetAddress.toString(message.getFrom())).append("<br/>");
            result.append("Theme:   ").append(message.getSubject()).append("<br/>");
            String messageContent = new String();
            String contentType = message.getContentType();

            if (contentType.contains("multipart")) {
                Multipart multiPart = (Multipart) message.getContent();
                int numberOfParts = multiPart.getCount();
                for (int partCount = 0; partCount < numberOfParts; partCount++) {
                    MimeBodyPart part = (MimeBodyPart) multiPart.getBodyPart(partCount);
                    messageContent = part.getContent().toString();
                }
            } else if (contentType.contains("text/plain")
                    || contentType.contains("text/html")) {
                Object content = message.getContent();
                if (content != null) {
                    messageContent = content.toString();
                }
            }
            else {
                messageContent = message.getContent().toString();
            }
            //result.append("<div class='hidden' style='display:none;'>Message:   ").append(messageContent).append("</div>");
            result.append("Message: ").append(messageContent).append("<br/>");

            result.append("Date:    ").append(message.getSentDate()).append("</p>");
            result.append("</div>");
            result.append("-----------------------------------------------");
            result.append("</br>");

            /*emailCount++;*/
        }

        folder.close(true);
        store.close();
        return result.toString();
    }
}
