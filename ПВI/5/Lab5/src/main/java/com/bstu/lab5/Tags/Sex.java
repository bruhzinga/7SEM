package com.bstu.lab5.Tags;

import javax.servlet.jsp.JspException;
import javax.servlet.jsp.JspWriter;
import javax.servlet.jsp.tagext.TagSupport;
import java.io.IOException;

public class Sex extends TagSupport
{
    static String content = "<label>Sex&nbsp &nbsp</label>"
            + "<input name =\"sex\" value=\"Man\" type = \"radio\" >Man</input>"
            + "<input name =\"sex\" value=\"Woman\" type = \"radio\">Woman</input> ";

    @Override
    public int doStartTag() throws JspException
    {
        JspWriter out = pageContext.getOut();
        try
        {
            out.print(content);
        }
        catch (IOException e)
        {
            System.out.println("Sex: " + e);
        }
        return SKIP_BODY;
    }
}
