<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="StyleSheet.css" rel="stylesheet" type="text/css"/>
    <title>Rolling Dice Game</title>
</head>


<body>
    <div class="container">
    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div class="jumbotron" id="jumbo1">       
        <h1>THE DICE GAME</h1><br />
            <asp:Label ID="TotalCredit" runat="server" Text="Credit:"></asp:Label>
        <asp:TextBox ID="CreditValue" runat="server" Text="500" cssClass="allTextBoxes" ReadOnly="True"></asp:TextBox><br /><br /> 
            <asp:Label ID="Rolls" runat="server" Text="Rolls Left:"></asp:Label>
            <asp:TextBox ID="RollsLeft" runat="server" cssClass="allTextBoxes" ReadOnly="True" Text="10"></asp:TextBox><br /><br />
            <asp:Label ID="Instructions" runat="server" Text="Roll the dice to win more credit! Can you reach 10,000 credit with only 10 rolls?"></asp:Label><br /><br />
            <asp:Label ID="DiceResult" runat="server" Text=""></asp:Label><br /><br />
            <asp:Image ID="DieOneResultImage" runat="server" Height="100px" Width="100px" Visible="False" />
            <asp:Image ID="DieTwoResultImage" runat="server" Height="100px" Width="100px" Visible="False" />
            <asp:Image ID="DieThreeResultImage" runat="server" Height="100px" Width="100px" Visible="False" />
                <br /><asp:Label ID="Result" runat="server"></asp:Label>
            <asp:Label ID="ErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label><br /><br />
            <asp:Button ID="RestartButton" class="restartbtn" runat="server" Text="Restart" OnClick="RestartButton_Click" Visible="False" /> 
                 </div>
                 
                <div class="row">  
                            <div class="col-sm-6"> 
                                <div class="jumbotron" id="jumbo2">
                <asp:Label ID="Label1" runat="server" Text="Enter below the number of dice to roll, the amount of credit you wish to stake and the amount you must beat with your dice score:"></asp:Label><br /><br />                   
                <asp:Label ID="NoOfDice" runat="server" Text="Number of dice: "></asp:Label>
                <asp:DropDownList ID="NoOfDiceInput" runat="server">
                    <asp:ListItem Value="1"></asp:ListItem>
                    <asp:ListItem Value="2"></asp:ListItem>
                    <asp:ListItem Value="3"></asp:ListItem>
                    </asp:DropDownList><br /><br />
                <asp:Label ID="ToBeat" runat="server" Text="Amount to beat: "></asp:Label>
                <asp:TextBox ID="ToBeatInput" runat="server" cssClass="allTextBoxes" TextMode="Number"></asp:TextBox><br /><br />
                <asp:Label ID="Wager" runat="server" Text="Amount to stake: "></asp:Label>
                <asp:TextBox ID="WagerInput" runat="server" ValidateRequestMode="Inherit" cssClass="allTextBoxes" TextMode="Number"></asp:TextBox><br /><br />
                <asp:Button ID="CalculateButton" class="calcbtn" runat="server" Text="Calculate" OnClick="CalculateButton_Click" /><br />
                
                    </div>
                </div>               
                     
                <div class="col-sm-6">
                    <div class="jumbotron" id="jumbo3">   
                <asp:Label ID="Label2" runat="server" Text="What will happen? Once you press 'Calculate', the chance of success and the amount you stand to win will appear. Then press 'Roll the Dice!' to see what happens!"></asp:Label><br /><br />   
                <asp:Label ID="Label5" runat="server" Text="Odds of success: "></asp:Label>
                <asp:Label ID="MinSuccessOutput" runat="server"></asp:Label><br /><br />      
                <asp:Label ID="Label9" runat="server" Text="Amount to win: "></asp:Label>
                 <asp:Label ID="MinToWinOutput" runat="server"></asp:Label><br /><br /><br />
                <asp:Button ID="DiceRoll" class="dicebtn" runat="server" Text="Roll the Dice!" OnClick="diceRoll_Click" /><br />
                     </div>
                    </div>                      
                </div>
                <div>
                    <p id="disclaimer">
                        Disclaimer: this is a non-commercial, demonstration site. This site does not in any way faciliate payment or receipt of actual money
                        and should not be viewed as a gambling site or to be advocating or promoting gambling in any way whatsoever.
                    </p>
                </div>                   
            </ContentTemplate>
        </asp:UpdatePanel> 
     

    
    </form>
    </div>
</body>
</html>
