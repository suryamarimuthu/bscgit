
var yahooPanel;          
function ShowYahooScreen(title)
{
    yahooPanel = new YAHOO.widget.Panel("WaitPanel",
        { width:"200px",
          fixedcenter:true,
          underlay:"shadow",
          close:false,
          visible:true,
          draggable:false,
          modal:true});
    yahooPanel.setHeader(title);
    yahooPanel.setBody("<img src=\"../images/progress_bar.gif\"/>");
    yahooPanel.render(document.body);
    yahooPanel.show();
    return true;
}
 
function HideYahooScreen()
{
    if (yahooPanel)
    {
        yahooPanel.hide();
    }
}

function YahooStatus()
{
    ShowYahooScreen("Loading, Please wait...");
    CallServer("Yahoo","HideYahooScreen()");
    return false;
}


function ReceiveServerData(rValue,context)
{   
    eval(context);
}

function CustomStatus()
{
    ShowCustomScreen();
    ShowProgressBar();
    CallServer("Custom","HideCustomScreen()");
    return false;
}

function ShowCustomScreen()
{
    var page_backgnd = document.getElementById('page_backgnd');
    page_backgnd.style.height = self.screen.availHeight+'px';
    page_backgnd.style.display = 'block';
}

function  ShowProgressBar()
{
    
    var progressBar = document.getElementById('progressBar');
    
    var width = 50;
    var height = 50;
 
    var x = Math.round((self.screen.availWidth/3))
    var y = Math.round((self.screen.availHeight/4))
    
    // set the coordinates of the progress bar
    progressBar.style.left = x + "px";
    progressBar.style.top  = y + "px";
    progressBar.style.display = 'block';
}

function HideCustomScreen()
{
    if (document.getElementById('progressBar'))
    document.getElementById('progressBar').style.display = 'none';
   
   if (document.getElementById('page_backgnd'))
         document.getElementById('page_backgnd').style.display = 'none';
}