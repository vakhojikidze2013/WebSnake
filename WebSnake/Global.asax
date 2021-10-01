<%@ Application Language="C#" %>

<%@ Import Namespace="System.Threading" %>
<%@ Import Namespace="System.Timers" %>

<script runat="server">

    TimeScheduler TimerMethod = new TimeScheduler();

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

        //Timer initialization. timer interval is set in miliseconds,
        System.Timers.Timer timeSchedulerTask = new System.Timers.Timer();
        timeSchedulerTask.Interval = 100;
        timeSchedulerTask.Enabled = true;
        // Add handler for Elapsed event
        timeSchedulerTask.Elapsed += new System.Timers.ElapsedEventHandler(TimeSchedulerTaskElapsed);

    }

    void TimeSchedulerTaskElapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        //Execute some task!!!
        TimerMethod.DoWork();
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
