package com.bstu.lab9.Listeners;

import javax.servlet.http.HttpSessionAttributeListener;
import javax.servlet.http.HttpSessionBindingEvent;

public class L2 implements HttpSessionAttributeListener
{
    @Override
    public void attributeAdded(HttpSessionBindingEvent httpSessionBindingEvent)
    {
      System.out.println("Attribute added");
    }

    @Override
    public void attributeRemoved(HttpSessionBindingEvent httpSessionBindingEvent)
    {
      System.out.println("Attribute removed");
    }

    @Override
    public void attributeReplaced(HttpSessionBindingEvent httpSessionBindingEvent)
    {
      System.out.println("Attribute replaced");
    }
}
