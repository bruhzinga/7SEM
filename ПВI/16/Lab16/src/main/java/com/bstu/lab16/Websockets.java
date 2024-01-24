package com.bstu.lab16;

import javax.websocket.*;
import javax.websocket.server.ServerEndpoint;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

@ServerEndpoint("/websockets")
public class Websockets extends Endpoint
{
    @Override
    public void onOpen(Session session, EndpointConfig endpointConfig)
    {
        SimpleDateFormat format = new SimpleDateFormat("hh:mm:ss");
        try
        {
            while(true)
            {
              Thread.sleep(2000);
              session.getBasicRemote().sendText(format.format(new Date()));
            }
        }
        catch( IOException | InterruptedException e)
        {
          e.printStackTrace();
        }
    }
}
