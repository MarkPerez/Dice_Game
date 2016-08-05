using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //global variables to represent user input and output
    int numOfDice;
    int noToBeat;
    int stake;
    double oddsToBeat;

    Boolean error = false;
    Boolean gameOver = false;

    //to generate each dice roll    
    static Random random = new Random();
    int firstdieRoll = random.Next(1, 7);
    int seconddieRoll = random.Next(1, 7);
    int thirddieRoll = random.Next(1, 7);

    //persistent control variable to ensure that ScrollToTop method works first time
    // - without this ScrollToTop does not work first time
    int noOfLoad
    {
        get
        {
            int retVal = 0;
            if (ViewState["controlNoToBeat"] != null)
                Int32.TryParse(ViewState["controlNoToBeat"].ToString(), out retVal);

            return retVal;
        }
        set { ViewState["controlNoToBeat"] = value; }
    }

    //persistent control variables to ensure user cannot roll the dice after changing input data but not recalculating new odds and winnings
    int controlNoOfDice
    {
        get
        {
            int retVal = 0;
            if (ViewState["controlNoOfDice"] != null)
                Int32.TryParse(ViewState["controlNoOfDice"].ToString(), out retVal);

            return retVal;
        }
        set { ViewState["controlNoOfDice"] = value; }
    }

    int controlNoToBeat
    {
        get
        {
            int retVal = 0;
            if (ViewState["controlNoToBeat"] != null)
                Int32.TryParse(ViewState["controlNoToBeat"].ToString(), out retVal);

            return retVal;
        }
        set { ViewState["controlNoToBeat"] = value; }
    }

    int controlStake
    {
        get
        {
            int retVal = 0;
            if (ViewState["controlStake"] != null)
                Int32.TryParse(ViewState["controlStake"].ToString(), out retVal);

            return retVal;
        }
        set { ViewState["controlStake"] = value; }
    }

    //to count down remaining turns
    int remainingTurns
    {
        get
        {
            int retVal = 0;
            if (ViewState["remainingTurns"] != null)
                Int32.TryParse(ViewState["remainingTurns"].ToString(), out retVal);

            return retVal;
        }
        set { ViewState["remainingTurns"] = value; }
    }

    //method for calculating odds of success using one die
    public void CalculateOdds1()
    {
        noToBeat = Convert.ToInt32(ToBeatInput.Text);
        int singleNo = 1;

        //number to beat must be between 1 and 5
        if (noToBeat >= 1 && noToBeat <= 5)
        {
            //for loop to iterate through calculations until correct calculation for user's number to beat
            //has been reached, upon which for loop will break
            for (int i = 5; i >= 1; i--)
            {
                oddsToBeat = ((double)singleNo / 6) * 100;
                singleNo++;
                if (noToBeat == i)
                {
                    break;
                }
            }
            MinSuccessOutput.Text = Math.Round(oddsToBeat, 2).ToString() + "%";
            error = false;
        }

        else
        {
            ErrorMessage.Text = "Please enter an amount to beat between 1 and 5!";
            MinSuccessOutput.Text = "";
            MinToWinOutput.Text = "";
            error = true;
        }


    }

    //method for calculating odds of success using two dice
    public void CalculateOdds2()
    {
        noToBeat = Convert.ToInt32(ToBeatInput.Text);

        //if number to beat is between 6 and 11
        if (noToBeat >= 6 && noToBeat <= 11)
        {
            int triNo = 1;

            //for loop to iterate through calculations and break where neccessary.
            //Formula now uses triangular numbers
            for (int i = 11; i >= 6; i--)
            {
                oddsToBeat = ((((double)triNo * (triNo + 1)) / 2) / 36) * 100;
                triNo++;
                if (noToBeat == i)
                {
                    break;
                }
            }
            MinSuccessOutput.Text = Math.Round(oddsToBeat, 2).ToString() + "%";
            error = false;
        }
        //if number to beat is between 2 and 5
        else if (noToBeat >= 2 && noToBeat <= 5)
        {
            int triNo = 7;
            int quadNo = 1;

            //formula adapted as number to beat between 2 and 5
            for (int i = 5; i >= 2; i--)
            {
                oddsToBeat = (((((double)triNo * (triNo + 1)) / 2) - ((double)quadNo * (quadNo + 1))) / 36) * 100;
                triNo++;
                quadNo++;
                if (noToBeat == i)
                {
                    break;
                }
            }
            MinSuccessOutput.Text = Math.Round(oddsToBeat, 2).ToString() + "%";
            error = false;
        }

        else
        {
            ErrorMessage.Text = "Please enter an amount to beat between 2 and 11!";
            MinSuccessOutput.Text = "";
            MinToWinOutput.Text = "";
            error = true;
        }
    }

    //method for calculating odds of success using three dice
    public void CalculateOdds3()
    {
        noToBeat = Convert.ToInt32(ToBeatInput.Text);

        //if number to beat is between 12 and 17
        if (noToBeat >= 12 && noToBeat <= 17)
        {
            int tetraNo = 1;

            //for loop to iterate through calculations and break where neccessary.
            //Formula now uses tetrahedral numbers
            for (int i = 17; i >= 12; i--)
            {
                oddsToBeat = ((((double)(tetraNo) * (tetraNo + 1) * (tetraNo + 2)) / 6) / 216) * 100;
                tetraNo++;

                if (noToBeat == i)
                {
                    break;
                }
            }
            MinSuccessOutput.Text = Math.Round(oddsToBeat, 2).ToString() + "%";
            error = false;
        }

        //if number to beat is between 6 and 11
        else if (noToBeat >= 6 && noToBeat <= 11)
        {
            int tetraNo = 7;
            int seqNo = 1;

            //formula adapted as number to beat between 6 and 11
            for (int i = 11; i >= 6; i--)
            {
                oddsToBeat = (((((double)(tetraNo) * (tetraNo + 1) * (tetraNo + 2)) / 6) - ((double)(seqNo) * (seqNo + 1) * (seqNo + 2) / 2)) / 216) * 100;
                tetraNo++;
                seqNo++;

                if (noToBeat == i)
                {
                    break;
                }
            }
            MinSuccessOutput.Text = Math.Round(oddsToBeat, 2).ToString() + "%";
            error = false;
        }

        //if number to beat is between 3 and 5
        else if (noToBeat >= 3 && noToBeat <= 5)
        {
            int tetraNo = 13;
            int seqNo = 7;
            int finalNo = 1;

            //formula further adapted as number to beat between 3 and 5
            for (int i = 5; i >= 3; i--)
            {
                oddsToBeat = (((((double)(tetraNo) * (tetraNo + 1) * (tetraNo + 2)) / 6) - ((((double)(seqNo) * (seqNo + 1) * (seqNo + 2)) / 2) - ((double)(finalNo) * (finalNo + 1) * (finalNo + 2)) / 2)) / 216) * 100;
                tetraNo++;
                seqNo++;
                finalNo++;

                if (noToBeat == i)
                {
                    break;
                }
            }
            MinSuccessOutput.Text = Math.Round(oddsToBeat, 2).ToString() + "%";
            error = false;
        }

        else
        {
            ErrorMessage.Text = "Please enter an amount to beat between 3 and 17!";
            MinSuccessOutput.Text = "";
            MinToWinOutput.Text = "";
            error = true;
        }

    }

    //winnings calculated, by multiplying stake by 1 over the square of the odds of success over 50
    public void MinToWin()
    {
        stake = Convert.ToInt32(WagerInput.Text);
        noToBeat = Convert.ToInt32(ToBeatInput.Text);
        double amountToWin;

        if (error == false)
        {
            amountToWin = (double)stake * (1 / Math.Pow((oddsToBeat / 50), 2.0));
            MinToWinOutput.Text = Math.Round(amountToWin).ToString();
        }
    }

    //method for rolling the dice 
    public void RollDice()
    {
        ErrorMessage.Text = "";
        int diceResult;
        int winnings;
        numOfDice = Convert.ToInt32(NoOfDiceInput.Text);
        noToBeat = Convert.ToInt32(ToBeatInput.Text);
        stake = Convert.ToInt32(WagerInput.Text);

        //switch statement based on number of dice rolled
        switch (numOfDice)
        {
            case 1:
                DiceResult.Text = firstdieRoll.ToString();
                break;

            case 2:
                DiceResult.Text = (firstdieRoll + seconddieRoll).ToString();
                break;

            case 3:
                DiceResult.Text = (firstdieRoll + seconddieRoll + thirddieRoll).ToString();
                break;

            default:
                DiceResult.Text = "";
                break;
        }

        //decrease remaining turns after each dice roll
        remainingTurns = (Convert.ToInt32(RollsLeft.Text) - 1);
        RollsLeft.Text = remainingTurns.ToString();

        diceResult = Convert.ToInt32(DiceResult.Text);

        //calculate new credit balance depending on whether dice roll was successful or not
        if (diceResult > noToBeat)
        {
            winnings = Convert.ToInt32(MinToWinOutput.Text);
            int newCreditBalance = Convert.ToInt32(CreditValue.Text) + winnings;
            CreditValue.Text = newCreditBalance.ToString();
            Result.Text = "Success!";
        }
        else
        {
            int newCreditBalance = Convert.ToInt32(CreditValue.Text) - stake;
            CreditValue.Text = newCreditBalance.ToString();
            Result.Text = "Bad luck!";
        }
    }

    //create image for first die
    public void CreateDieOneImage()
    {
        //each die result generates different image
        switch (firstdieRoll)
        {
            case 1:
                DieOneResultImage.ImageUrl = "DieRoll1.png";
                break;

            case 2:
                DieOneResultImage.ImageUrl = "DieRoll2.png";
                break;

            case 3:
                DieOneResultImage.ImageUrl = "DieRoll3.png";
                break;

            case 4:
                DieOneResultImage.ImageUrl = "DieRoll4.png";
                break;

            case 5:
                DieOneResultImage.ImageUrl = "DieRoll5.png";
                break;

            case 6:
                DieOneResultImage.ImageUrl = "DieRoll6.png";
                break;

            default:
                break;
        }
    }

    //create image for second die
    public void CreateDieTwoImage()
    {
        switch (seconddieRoll)
        {
            case 1:
                DieTwoResultImage.ImageUrl = "DieRoll1.png";
                break;

            case 2:
                DieTwoResultImage.ImageUrl = "DieRoll2.png";
                break;

            case 3:
                DieTwoResultImage.ImageUrl = "DieRoll3.png";
                break;

            case 4:
                DieTwoResultImage.ImageUrl = "DieRoll4.png";
                break;

            case 5:
                DieTwoResultImage.ImageUrl = "DieRoll5.png";
                break;

            case 6:
                DieTwoResultImage.ImageUrl = "DieRoll6.png";
                break;

            default:
                break;
        }
    }

    //create image for third die
    public void CreateDieThreeImage()
    {
        switch (thirddieRoll)
        {
            case 1:
                DieThreeResultImage.ImageUrl = "DieRoll1.png";
                break;

            case 2:
                DieThreeResultImage.ImageUrl = "DieRoll2.png";
                break;

            case 3:
                DieThreeResultImage.ImageUrl = "DieRoll3.png";
                break;

            case 4:
                DieThreeResultImage.ImageUrl = "DieRoll4.png";
                break;

            case 5:
                DieThreeResultImage.ImageUrl = "DieRoll5.png";
                break;

            case 6:
                DieThreeResultImage.ImageUrl = "DieRoll6.png";
                break;

            default:
                break;
        }
    }

    //Method to scroll to top of page
    public static void ScrollToTop()
    {
        string strScript = @"var manager = Sys.WebForms.PageRequestManager.getInstance(); 
            manager.add_beginRequest(beginRequest); 
            function beginRequest() 
            { 
                manager._scrollPosition = null; 
            }
            window.scroll(0, 0);";

        Page pagCurrent = GetCurrentPage();
        ScriptManager.RegisterStartupScript(pagCurrent, pagCurrent.GetType(), string.Empty, strScript, true);

        return;
    }

    public static Page GetCurrentPage()
    {
        return (HttpContext.Current.Handler as Page);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (noOfLoad == 0)
        {
            ScrollToTop();
            noOfLoad = 1;
        }
    }

    protected void CalculateButton_Click(object sender, EventArgs e)
    {
        ErrorMessage.Text = "";
        numOfDice = Convert.ToInt32(NoOfDiceInput.Text);
        //a number to beat must have been input for the calculation to proceed,
        //otherwise an error message appears
        if (ToBeatInput.Text != "")
        {
            //an amount to stake must have been input for the calculation to proceed,
            //otherwise an error message appears
            if (WagerInput.Text != "")
            {
                //the amount to stake must be greater than 0 and less than the current credit value,
                //otherwise an error message appears
                if (Convert.ToInt32(WagerInput.Text) <= Convert.ToInt32(CreditValue.Text) && Convert.ToInt32(WagerInput.Text) > 0)
                {
                    //choose odss of success calculation method depending on number of dice to roll
                    switch (numOfDice)
                    {
                        case 1:
                            CalculateOdds1();
                            break;

                        case 2:
                            CalculateOdds2();
                            break;

                        case 3:
                            CalculateOdds3();
                            break;

                        default:
                            break;
                    }

                    //calculate amount to win
                    MinToWin();

                }
                else
                {
                    if (Convert.ToInt32(WagerInput.Text) < 1)
                    {
                        ErrorMessage.Text = "You cannot stake less than 1 credit!";
                    }
                    else
                    {
                        ErrorMessage.Text = "You cannot stake more than your current credit amount!";
                    }
                    MinSuccessOutput.Text = "";
                    MinToWinOutput.Text = "";
                    error = true;
                }
            }
            else
            {
                ErrorMessage.Text = "Please enter an amount to stake!";
                MinSuccessOutput.Text = "";
                MinToWinOutput.Text = "";
                error = true;
            }
        }
        else
        {
            ErrorMessage.Text = "Please enter an amount to beat!";
            MinSuccessOutput.Text = "";
            MinToWinOutput.Text = "";
            error = true;
        }
        DiceResult.Text = "";
        Result.Text = "";

        //set control variables equal to current data input
        if (ToBeatInput.Text != "" && WagerInput.Text != "")
        {
            controlNoOfDice = Convert.ToInt32(NoOfDiceInput.Text);
            controlNoToBeat = Convert.ToInt32(ToBeatInput.Text);
            controlStake = Convert.ToInt32(WagerInput.Text);
        }
    }

    protected void diceRoll_Click(object sender, EventArgs e)
    {
        //odds of success and amount to win must have been calculated,
        //otherwise an error message appears
        if (MinSuccessOutput.Text != "" && MinToWinOutput.Text != "")
        {
            //current data input must mstch control variables, otherwise an error message
            //appears - this is to stop user rolling the dice after changing calculation data
            //but not recalculating odds of success and amount to win
            if (controlNoOfDice == Convert.ToInt32(NoOfDiceInput.Text) && controlNoToBeat == Convert.ToInt32(ToBeatInput.Text) && controlStake == Convert.ToInt32(WagerInput.Text))
            {
                //the amount to stake must be greater than 0 and less than the current credit value,
                //otherwise an error message appears
                if (Convert.ToInt32(WagerInput.Text) <= Convert.ToInt32(CreditValue.Text) && Convert.ToInt32(WagerInput.Text) > 0)
                {
                    RollDice();
                    switch (numOfDice)
                    {
                        case 1:
                            //set first die image and make visible
                            CreateDieOneImage();
                            DieOneResultImage.Visible = true;
                            DieTwoResultImage.Visible = false;
                            DieThreeResultImage.Visible = false;
                            break;

                        case 2:
                            //set first two dice images and make visible
                            CreateDieOneImage();
                            CreateDieTwoImage();
                            DieOneResultImage.Visible = true;
                            DieTwoResultImage.Visible = true;
                            DieThreeResultImage.Visible = false;
                            break;

                        case 3:
                            //set all dice images and make visible
                            CreateDieOneImage();
                            CreateDieTwoImage();
                            CreateDieThreeImage();
                            DieOneResultImage.Visible = true;
                            DieTwoResultImage.Visible = true;
                            DieThreeResultImage.Visible = true;
                            break;

                        default:
                            break;
                    }

                    //set victory conditions
                    if (Convert.ToInt32(CreditValue.Text) >= 10000)
                    {
                        Result.Text = "YOU HAVE WON!";
                        gameOver = true;
                    }

                    else if (remainingTurns == 0)
                    {
                        Result.Text = "GAME OVER!";
                        ErrorMessage.Text = "No more rolls!";
                        gameOver = true;
                    }

                    else if (CreditValue.Text == 0.ToString())
                    {
                        Result.Text = "GAME OVER!";
                        ErrorMessage.Text = "No more credit!";
                        gameOver = true;
                    }
                }
                else
                {
                    if (Convert.ToInt32(WagerInput.Text) < 1)
                    {
                        ErrorMessage.Text = "You cannot stake less than 1 credit!";
                    }
                    else
                    {
                        ErrorMessage.Text = "You cannot stake more than your current credit amount!";
                    }
                }
            }
            else
            {
                ErrorMessage.Text = "You have changed some of your calculation data! Please recalculate your new odds of success and amount to win by pressing the 'Calculate' button before rolling the dice!";
                DiceResult.Text = "";
                Result.Text = "";
            }
        }
        else
        {
            ErrorMessage.Text = "Please enter all the required data and press 'Calculate' before rolling the dice!";
        }

        if (gameOver)
        {
            CalculateButton.Enabled = false;
            DiceRoll.Enabled = false;
            RestartButton.Visible = true;
        }

        ScrollToTop();
    }

    //button to reset the game and all data once the game has finished
    protected void RestartButton_Click(object sender, EventArgs e)
    {
        CreditValue.Text = 500.ToString();
        RollsLeft.Text = 10.ToString();
        NoOfDiceInput.Text = 1.ToString();
        ToBeatInput.Text = "";
        WagerInput.Text = "";
        CalculateButton.Enabled = true;
        DiceRoll.Enabled = true;
        gameOver = false;
        MinSuccessOutput.Text = "";
        MinToWinOutput.Text = "";
        DiceResult.Text = "";
        Result.Text = "";
        ErrorMessage.Text = "";
        DieOneResultImage.Visible = false;
        DieTwoResultImage.Visible = false;
        DieThreeResultImage.Visible = false;
        RestartButton.Visible = false;
    }
}