package com.bstu.lab5.Tags;

import javax.servlet.jsp.JspException;
import javax.servlet.jsp.JspWriter;
import javax.servlet.jsp.tagext.TagSupport;
import java.io.IOException;

public class Submit extends TagSupport {
    String submitContent = "<input type='submit' value='ok' />" + " <input type='button' value='close' />";

    @Override
    public int doStartTag() throws JspException
    {
        JspWriter out = pageContext.getOut();
        try
        {
            out.print(submitContent);
        }
        catch (IOException e)
        {
            System.out.println("Submit:" + e);
        }
        return SKIP_BODY;
    }
}