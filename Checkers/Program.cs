using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

 

namespace finalCheckers{
    class Program{

        public struct player//holds value for each piece player has on the board
        {

            public int xAx;//will help locate and move piece along xAxis

            public int yAx;//will help locate and move piece along yAxis

            public string pieceView;//this is what will be displayed on the console via the 8x8 game board / the gameboard is a string array

            public bool kangPiece;//a different set of rules for player pieces that become kings

        }

 

        static void Main(string[] args){

            #region Game Setup

 

            string[,] gameBoard = new string[8, 8];//holds values of each square on the gameboard (8x8 as a checker board should be) / all pieces will be saved as string and padded left 4 spaces

            string[,] emptyBoard = new string[8, 8];//gameBoard copies emptyBoard at the beginning of each gameOn loop / gameBoard will then populate based on player coords in each player ary

 

            player[] player1 = new player[12];/* checkers starts 12 v 12 / player1 at element 0 will contain the king (to be copied to any playable pieces that reaches the king milestone /

                                                     pieceView will equal "p1" / p1 as king will be k1*/

            #region player1's starting position

            //the following sequence builds each player on the board in the starting postion using literals

            player1 [0].xAx = 0; player1 [0].yAx = 1; player1 [0].kangPiece = false; player1 [0].pieceView = "p1";

            player1 [1].xAx = 0; player1 [1].yAx = 3; player1 [1].kangPiece = false; player1 [1].pieceView = "p1";

            player1 [2].xAx = 0; player1 [2].yAx = 5; player1 [2].kangPiece = false; player1 [2].pieceView = "p1";

            player1 [3].xAx = 0; player1 [3].yAx = 7; player1 [3].kangPiece = false; player1 [3].pieceView = "p1";

            player1 [4].xAx = 1; player1 [4].yAx = 0; player1 [4].kangPiece = false; player1 [4].pieceView = "p1";

            player1 [5].xAx = 1; player1 [5].yAx = 2; player1 [5].kangPiece = false; player1 [5].pieceView = "p1";

            player1 [6].xAx = 1; player1 [6].yAx = 4; player1 [6].kangPiece = false; player1 [6].pieceView = "p1";

            player1 [7].xAx = 1; player1 [7].yAx = 6; player1 [7].kangPiece = false; player1 [7].pieceView = "p1";

            player1 [8].xAx = 2; player1 [8].yAx = 1; player1 [8].kangPiece = false; player1 [8].pieceView = "p1";

            player1 [9].xAx = 2; player1 [9].yAx = 3; player1 [9].kangPiece = false; player1 [9].pieceView = "p1";

            player1[10].xAx = 2; player1[10].yAx = 5; player1[10].kangPiece = false; player1[10].pieceView = "p1";

            player1[11].xAx = 2; player1[11].yAx = 7; player1[11].kangPiece = false; player1[11].pieceView = "p1";

            //all player 1 pieces are in their correct space to start the game

            #endregion

 

            player[] player2 = new player[12];// same as player1 but pieceView will equal "p2" / p2 as king will be k2

            #region player2's starting position

           //the following sequence builds each player on the board in the starting postion using literals

            player2 [0].xAx = 5; player2 [0].yAx = 0; player2 [0].kangPiece = false; player2 [0].pieceView = "p2";

            player2 [1].xAx = 5; player2 [1].yAx = 2; player2 [1].kangPiece = false; player2 [1].pieceView = "p2";

            player2 [2].xAx = 5; player2 [2].yAx = 4; player2 [2].kangPiece = false; player2 [2].pieceView = "p2";

            player2 [3].xAx = 5; player2 [3].yAx = 6; player2 [3].kangPiece = false; player2 [3].pieceView = "p2";

            player2 [4].xAx = 6; player2 [4].yAx = 1; player2 [4].kangPiece = false; player2 [4].pieceView = "p2";

            player2 [5].xAx = 6; player2 [5].yAx = 3; player2 [5].kangPiece = false; player2 [5].pieceView = "p2";

            player2 [6].xAx = 6; player2 [6].yAx = 5; player2 [6].kangPiece = false; player2 [6].pieceView = "p2";

            player2 [7].xAx = 6; player2 [7].yAx = 7; player2 [7].kangPiece = false; player2 [7].pieceView = "p2";

            player2 [8].xAx = 7; player2 [8].yAx = 0; player2 [8].kangPiece = false; player2 [8].pieceView = "p2";

            player2 [9].xAx = 7; player2 [9].yAx = 2; player2 [9].kangPiece = false; player2 [9].pieceView = "p2";

            player2[10].xAx = 7; player2[10].yAx = 4; player2[10].kangPiece = false; player2[10].pieceView = "p2";

            player2[11].xAx = 7; player2[11].yAx = 6; player2[11].kangPiece = false; player2[11].pieceView = "p2";

            //all player 1 pieces are in their correct space to start the game

            #endregion

 

            bool whosTurn = true; // when true its player1's turn / if you don't know what false is, this is maybe a lost cause

            Dictionary<bool, string> yourTurn = new Dictionary<bool, string>();//this will ensure the turns are established / test the string against the board to see if a player's pieceView matches the string of the value returned

            yourTurn.Add(whosTurn == true, "p1");//type this : yourTurn[whosTurn] (if whosTurn is true, this will retun "p1" as a string)

            yourTurn.Add(whosTurn == false, "p2");//type this : yourTurn[whosTurn] (if whosTurn is false, this will retun "p2" as a string)

           

 

            Dictionary<string, string> spaceName = new Dictionary<string, string>();/*each playabele space will have a corresponding spaceName

                                                  (enter spaceName["blah"] and in return get its x axis coord in element 0 and its y axis coord in element 1)*/

            #region spaceName assignment

            //each playable spot will have a name so its distinguishable from the others /

            //ex: spaceName.Add("B1", "01") / if user enters "B1" the corresponding gameBoard space is x-Axis = 0 , y-Axis = 1;

 

            spaceName.Add("A2", "0 1");

            spaceName.Add("A4", "0 3");

            spaceName.Add("A6", "0 5");

            spaceName.Add("A8", "0 7");

            spaceName.Add("B1", "1 0");

            spaceName.Add("B3", "1 2");

            spaceName.Add("B5", "1 4");

            spaceName.Add("B7", "1 6");

            spaceName.Add("C2", "2 1");

            spaceName.Add("C4", "2 3");

            spaceName.Add("C6", "2 5");

            spaceName.Add("C8", "2 7");

            spaceName.Add("D1", "3 0");

            spaceName.Add("D3", "3 2");

            spaceName.Add("D5", "3 4");

            spaceName.Add("D7", "3 6");

            spaceName.Add("E2", "4 1");

            spaceName.Add("E4", "4 3");

            spaceName.Add("E6", "4 5");

            spaceName.Add("E8", "4 7");

            spaceName.Add("F1", "5 0");

            spaceName.Add("F3", "5 2");

            spaceName.Add("F5", "5 4");

            spaceName.Add("F7", "5 6");

            spaceName.Add("G2", "6 1");

            spaceName.Add("G4", "6 3");

            spaceName.Add("G6", "6 5");

            spaceName.Add("G8", "6 7");

            spaceName.Add("H1", "7 0");

            spaceName.Add("H3", "7 2");

            spaceName.Add("H5", "7 4");

            spaceName.Add("H7", "7 6");

            #endregion

            #endregion

 

            bool gameOn = true;//while true, the game continues

            while (gameOn){//the loop erases and rewrites gameboard after each move

                List<player> returnPlayer1 = new List<player>();

                List<player> returnPlayer2 = new List<player>();

                bool makingMoves = false;//if false, a valid move has not been made

                bool goodMove = false;

 

                player[] runThru = new player[1]; //will be used to run through the player[] to find a matching piece

 

                 switch (yourTurn[whosTurn]){//checks to see current player /

                     case "p1": { runThru = player1; break; }//if its player 1's turn, we will run through the player1's pieces for a valid piece

                     case "p2": { runThru = player2; break; }//As above (but with player2)

                 }

 

                Console.Clear();

 

                #region updatesBoard

                //gameboard is now empty / the following will repopulate it based on the coordinates of each gamepiece in the player array

                for (int xLine = 0; xLine < gameBoard.GetLength(0); xLine ++){//x-Axis / from left to right

                    for (int yLine = 0; yLine < gameBoard.GetLength(1); yLine ++){//y-Axis / from top to bottom

                        for (int playerCheck1 = 0; playerCheck1 < player1.Length; playerCheck1++){   /*will run through player1 ary to find any matching coordinates /

                                                                                                    any match will be stored to gameboard below*/


                            if (player1[playerCheck1].yAx == yLine && player1[playerCheck1].xAx == xLine){//if this spot in the gameboard has a player 1 piece with matching coords

                                gameBoard[xLine, yLine] = player1[playerCheck1].pieceView;//this spot in the gameboard will equal p1 or k1 (the pieceView)

                                break;//breaks the loop because the gameBoard coordinate is filled (so no need to continue searching / one piece can occupy one space at a time)

                            } else {

                                gameBoard[xLine, yLine] = " ";

                            }

                        }//end for

                        for (int playerCheck2 = 0; playerCheck2 < player2.Length; playerCheck2++){       /* As Above

                                                                                                        So Below (but with player2)*/

                            if (gameBoard[xLine,yLine] == " ")

                            {

                                if (player2[playerCheck2].xAx == xLine && player2[playerCheck2].yAx == yLine)//if this spot in the gameboard has a player 2 piece with matching coords

                                {

                                    gameBoard[xLine, yLine] = player2[playerCheck2].pieceView;//this spot in the gameboard will equal p2 or k2 (the pieceView)

                                    break;//breaks the loop because the gameBoard coordinate is filled (so no need to continue searching / one piece can occupy one space at a time)

                                }

                            }

                           

                        }//end for

 

                    }

                }

                #endregion//allmoves have been saved to the board

 

                #region writesBoard

                for (int newX = 0; newX < gameBoard.GetLength(0); newX++)//new x axis / coords are the same but the string within could change

                {

                    for (int newY = 0; newY < gameBoard.GetLength(1); newY++)//new y axis

                    {

                        if (newX % 2 == 0 && newY % 2 == 1 || newX % 2 == 1 && newY % 2 == 0)//determines if coords create a playable spot or not

                        {

                            if (gameBoard[newX, newY] == "p1" || gameBoard[newX, newY] == "k1")//if the string inside the coord represents player 1

                            {

                                Console.BackgroundColor = ConsoleColor.Blue;//all playablespots are blue

                                Console.ForegroundColor = ConsoleColor.Cyan;//player 1 is yellow

                                Console.Write(gameBoard[newX,newY].PadLeft(4, ' '));//writes the content / pad left by 4 to ensure all spots are even in size

                                Console.BackgroundColor = ConsoleColor.Black;//changes the background color back to default

                                Console.ForegroundColor = ConsoleColor.White;

                            }

                            else if (gameBoard[newX, newY] == "p2" || gameBoard[newX, newY] == "k2")//As above

                            {                                                                       //So below (but with player 2)

                                Console.BackgroundColor = ConsoleColor.Blue;//all playable spots are blue

                                Console.ForegroundColor = ConsoleColor.White;//player 2 is cyan

                                Console.Write(gameBoard[newX, newY].PadLeft(4, ' '));//write content / pad left by 4 to ensure all spots are even in size

                                Console.BackgroundColor = ConsoleColor.Black;//backgound back to default

                                Console.ForegroundColor = ConsoleColor.White;

                            }

                            else//an empty playable spot

                            {

                                Console.BackgroundColor = ConsoleColor.Blue;//show playable spot as empty

                                Console.ForegroundColor = ConsoleColor.Blue;//guarantees the spot will look empty as the foreground is same color as the background

                                Console.Write("X".PadLeft(4, ' '));//will write an X so the console has something to pad left, ensuring size parity

                                Console.BackgroundColor = ConsoleColor.Black;//return background color to default

                                Console.ForegroundColor = ConsoleColor.White;

                            }

                        }

                        else//the spaces that are not playable positions will always be white spaces

                        {

                            Console.BackgroundColor = ConsoleColor.White;//unplayable spaces are white

                            Console.ForegroundColor = ConsoleColor.White;//because the spot is unplayable it shall always look empty (background same color as foreground)

                            Console.Write("X".PadLeft(4,' '));//will write an X so the console has something to pad left, ensuring size parity

                            Console.BackgroundColor = ConsoleColor.Black;//return background color to default

                            Console.ForegroundColor = ConsoleColor.White;//return foreground color to default

                        }

                    }

                    switch(newX)//used to label each horizontal line (row 0 will now be known as row A, row 1 is B, and so on (see subsequent code))

                    {

                        case 0: { Console.Write(" A"); break; }

                        case 1: { Console.Write(" B"); break; }

                        case 2: { Console.Write(" C"); break; }

                        case 3: { Console.Write(" D"); break; }

                        case 4: { Console.Write(" E"); break; }

                        case 5: { Console.Write(" F"); break; }

                        case 6: { Console.Write(" G"); break; }

                        case 7: { Console.Write(" H"); break; }

                    }

                    Console.WriteLine();//moves cursor to next line after labeling the row with its corresponding alphabet

                }

                Console.WriteLine(" 1   2   3   4   5   6   7   8  ");//labels each vertical lines (the format is literal (so to adjust the string is to adjust the output))

                Console.WriteLine();//this newlines the cursors position to the next line under the borad and its labels

                #endregion //rewrites the board after every move

 

                bool ValidPiece = false;//if false, a playable piece has not been selected for movement

                int[] moveThis = new int[2];//will hold coordinates for player's selected piece to play / look below to fully understand

                int[] moveTo = new int[2];//holds integers for the player to move to

                int dontForget = 0;//will be used for console to remember from which element in the array it came

 

                while (!makingMoves) {
                                    /*user will be asked to select a piece according to its corresponding square.
                                      as long as a valid move has not been made, this loop will continue*/


                    if (!ValidPiece) {
                                    /*the first step in making a valid move is to select a valid piece ;

                                    this will loop until a valid piece is selected

                                    look below to see how it is determined*/

                    

                        Console.Write("{0}, its your turn. Which piece would you like to move?\t", yourTurn[whosTurn]);//asks players for the current coordinates of the piece they would like to move

                        string moveFrom = Console.ReadLine().ToUpper();//user enters coordinates (hopefully they're valid and won't break the program. if not we'll check below) / to upper to compensate the dictionary

                         if (spaceName.Keys.Contains(moveFrom) ) {
                            
                            //this checks to see if the dictionary contains the data entered by the user ("a2" || "A2" and so forth)

                            //yes there's a matching name

                               

                                string[] thePlaceholder = spaceName[moveFrom].Split();/*spaceName[moveFrom] returns a string containing the x-Axis "a space" and the y-Axis / split by the space to get a string[]

                                            thePlaceholder hase 2 elements the x-Axis as a string in thePlaceholder[0] and the y-Axis also string int thePlaceholder[1]*/

                                moveThis[0] = int.Parse(thePlaceholder[0]);//stores the xAxis as an int

                                moveThis[1] = int.Parse(thePlaceholder[1]);//stores the yaxis as an int

 

                                for(int i = 0; i < runThru.Length; i++){
                                //check each player in the runThru  / starts at 1 because the king clone is in element [0]

                                    if (runThru[i].xAx == moveThis[0] && runThru[i].yAx == moveThis[1]) {
                                    //if (player's X equals entered X AND player's Y equals entered Y)


                                        dontForget = i;//the element from which the piece was gathered

                                        ValidPiece = true;//a playable piece has been selected

                                        makingMoves = false;

                                        break;

                                    }

                                }//end for

                               

                         }

 

                       

                         if (ValidPiece == false) {

                            ValidPiece = false;

                            makingMoves = false;

                            Console.WriteLine("Not a valid piece. Press ENTER and try again.");

                            Console.ReadKey();

                         }

                                                  

                    } else {

 

                        while (!goodMove) {
                        
                            //while loop to check if move is valid

 

                            Console.Write("{0}, where would you like to place the piece?\t", yourTurn[whosTurn]);

                            string MoveToString = Console.ReadLine().ToUpper();

 

                            if (spaceName.Keys.Contains(MoveToString)) {

                                string[] thePlaceholder = spaceName[MoveToString].Split();/*spaceName[moveFrom] returns a string containing the x-Axis "a space" and the y-Axis / split by the space to get a string[]

                                                thePlaceholder hase 2 elements the x-Axis as a string in thePlaceholder[0] and the y-Axis also string int thePlaceholder[1]*/

 

                                moveTo[0] = int.Parse(thePlaceholder[0]);//stores the xAxis as an int

                                moveTo[1] = int.Parse(thePlaceholder[1]);//stores the yaxis as an int

                                string turnCheck = yourTurn[whosTurn];

                               if (gameBoard[moveTo[0], moveTo[1]] == " ") {//if space is blank, and piece is not a king

                                    player[] whichTeam = new player[1];


                                    gameBoard = updatedBoard(moveThis, moveTo, gameBoard, turnCheck);

 

                                    goodMove = true;

                                    makingMoves = true;

 

                                } else if (gameBoard[moveTo[0], moveTo[1]] != " "){

                                    Console.WriteLine("Something's in that spot, {0}. Try jumping over it or choosing a different piece", yourTurn[whosTurn]);

                                    moveThis = new int[2];

                                    moveTo = new int[2];

                                    ValidPiece = false;

                                    makingMoves = false;

                                    break;

 

                                }

                            } else {

                                goodMove = false;

                                Console.WriteLine("Not a valid move. Press ENTER and try again.");

                                Console.ReadKey();

 

                            }//end move validation if

 

                        }//end while

 

 

                    }//end input if

 

 

 

                }//end input validation while

               

                for (int x = 0; x < gameBoard.GetLength(0); x += 1) {

                    for (int y = 0; y < gameBoard.GetLength(1); y+= 1) {

                        string boardCheck = gameBoard[x, y];

                        player goesBack;

                        if (boardCheck == "p1" || boardCheck == "k1") {

                            if (boardCheck == "p1") {

                                goesBack.kangPiece = false;

                                goesBack.pieceView = "p1";

                                goesBack.xAx = x;

                                goesBack.yAx = y;

                                returnPlayer1.Add(goesBack);

                            } else if (boardCheck == "k1") {

                                goesBack.kangPiece = true;

                                goesBack.pieceView = "k1";

                                goesBack.xAx = x;

                                goesBack.yAx = y;

                                returnPlayer1.Add(goesBack);

                            }

 

                        } else if (boardCheck == "p2" || boardCheck == "k2") {

                            if (boardCheck == "p2") {

                                goesBack.kangPiece = false;

                                goesBack.pieceView = "p2";

                                goesBack.xAx = x;

                                goesBack.yAx = y;

                                returnPlayer2.Add(goesBack);

                            } else if (boardCheck == "k2") {

                                goesBack.kangPiece = true;

                                goesBack.pieceView = "k2";

                                goesBack.xAx = x;

                                goesBack.yAx = y;

                                returnPlayer2.Add(goesBack);

                            }

                        }//end player if

                    }//end for

                }//end for

 

                player1 = returnPlayer1.ToArray();

                player2 = returnPlayer2.ToArray();

               

                if (whosTurn == true) {

                    whosTurn = false;

                    goodMove = false;

                } else if (whosTurn == false) {

                    whosTurn = true;

                    goodMove = false;

                }

            }//end game while

 

            Console.ReadKey();

        }//End Main

 

        #region moveCheck

        static string[,] updatedBoard(int[] moveFrom, int[] moveTo, string[,] gameBoard, string p1op2){
            //p1op2 means player 1 or player 2 

            for (int xAxis = 0; xAxis < gameBoard.GetLength(0); xAxis++){

                for (int yAxis = 0; yAxis < gameBoard.GetLength(1); yAxis++){

                    int[] currentSpotInArray = { xAxis, yAxis };

                    int[] startingSpot = moveFrom;

                    int[] wantsToGoHere = moveTo;

                    bool makeAChoice = true;

                    int[] outOfBounds = new int[3];

                    int[] makeAJump = new int[3];

 

                    #region Player1

                    if (currentSpotInArray[0] == startingSpot[0] && currentSpotInArray[1] == startingSpot[1] && p1op2 == "p1"){

                        outOfBounds[0] = startingSpot[0] + 1;

                        outOfBounds[1] = startingSpot[1] - 1;

                        outOfBounds[2] = startingSpot[1] + 1;

                        makeAJump[0] = startingSpot[0] + 2;

                        makeAJump[1] = startingSpot[1] - 2;

                        makeAJump[2] = startingSpot[1] + 2;

                        int[] outForZero = { startingSpot[0] + 1, startingSpot[1] + 1 };//if y axis equals 0

                        int[] jumpFromZero = { startingSpot[0] + 2, startingSpot[1] + 2 };//jump from y

                        int[] outForSeven = { startingSpot[0] + 1, startingSpot[1] - 1 };

                        int[] jumpFromSeven = { startingSpot[0] + 2, startingSpot[1] - 2 };

 

                        #region Regular P1 not King

                        if ((yAxis != 0 || yAxis != 7) && gameBoard[xAxis, yAxis] == "p1")//not on the edge of the board

                        {

                            if (wantsToGoHere[0] == outOfBounds[0] && wantsToGoHere[1] >= outOfBounds[1] && wantsToGoHere[1] <= outOfBounds[2]){

                                gameBoard[wantsToGoHere[0], wantsToGoHere[1]] = "p1";

                                gameBoard[startingSpot[0], startingSpot[1]] = " ";

                                makeAChoice = false;

                                break;

                            } else if (wantsToGoHere[0] == makeAJump[0] && (wantsToGoHere[1] == makeAJump[1] || wantsToGoHere[1] == makeAJump[2]) && (gameBoard[currentSpotInArray[0] + 1, currentSpotInArray[1] - 1]) == "p2" || gameBoard[currentSpotInArray[0] + 1, currentSpotInArray[1] + 1] == "p2"){

                                if (gameBoard[currentSpotInArray[0] + 1, currentSpotInArray[1] - 1] == "p2" && wantsToGoHere[1] == makeAJump[1]){

                                    gameBoard[currentSpotInArray[0] + 1, currentSpotInArray[1] - 1] = " ";

                                    gameBoard[startingSpot[0], startingSpot[1]] = " ";

                                    gameBoard[wantsToGoHere[0], wantsToGoHere[1]] = "p1";

                                    makeAChoice = false;

                                } else if (gameBoard[currentSpotInArray[0] + 1, currentSpotInArray[1] + 1] == "p2" && wantsToGoHere[1] == makeAJump[2]) {

                                    gameBoard[currentSpotInArray[0] + 1, currentSpotInArray[1] + 1] = " ";

                                    gameBoard[startingSpot[0], startingSpot[1]] = " ";

                                    gameBoard[wantsToGoHere[0], wantsToGoHere[1]] = "p1";

                                    makeAChoice = false;

                                }

                            }

                        } else if (yAxis == 0){//moving from zero can't go left, so its regulated below

 

                            if (wantsToGoHere[0] == outForZero[0] && wantsToGoHere[1] == outForZero[1]){

                                gameBoard[wantsToGoHere[0], wantsToGoHere[1]] = "p1";

                                gameBoard[startingSpot[0], startingSpot[1]] = " ";

                                makeAChoice = false;

                                break;

                            } else if (wantsToGoHere[0] == jumpFromZero[0] && wantsToGoHere[1] == jumpFromZero[1] && gameBoard[currentSpotInArray[0] + 1, currentSpotInArray[1] + 1] == "p2"){

                                gameBoard[wantsToGoHere[0], wantsToGoHere[1]] = "p1";

                                gameBoard[currentSpotInArray[0] + 1, currentSpotInArray[1] + 1] = " ";

                                gameBoard[startingSpot[0], startingSpot[1]] = " ";

                                makeAChoice = false;

                            }//end yAxis = 0

                        } else if (yAxis == 7){

                            if (wantsToGoHere[0] == outForZero[0] && wantsToGoHere[1] == outForZero[1]){

                                gameBoard[wantsToGoHere[0], wantsToGoHere[1]] = "p1";

                                gameBoard[startingSpot[0], startingSpot[1]] = " ";

                                makeAChoice = false;

                                break;

                            } else if (wantsToGoHere[0] == jumpFromSeven[0] && wantsToGoHere[1] == jumpFromSeven[1] && gameBoard[currentSpotInArray[0] + 1, currentSpotInArray[1] - 1] == "p2"){

                                gameBoard[wantsToGoHere[0], wantsToGoHere[1]] = "p1";

                               gameBoard[currentSpotInArray[0] + 1, currentSpotInArray[1] + 1] = " ";

                                gameBoard[startingSpot[0], startingSpot[1]] = " ";

                                makeAChoice = false;

                            }

                        }

                        #endregion

                    }

                    #endregion

 

                    #region Player 2

                    else if (currentSpotInArray[0] == startingSpot[0] && currentSpotInArray[1] == startingSpot[1] && p1op2 == "p2"){

                        outOfBounds[0] = startingSpot[0] - 1;

                        outOfBounds[1] = startingSpot[1] - 1;

                        outOfBounds[2] = startingSpot[1] + 1;

                        makeAJump[0] = startingSpot[0] - 2;

                        makeAJump[1] = startingSpot[1] - 2;

                        makeAJump[2] = startingSpot[1] + 2;

                        int[] outForZero = { startingSpot[0] - 1, startingSpot[1] + 1 };//if y axis equals 0

                        int[] jumpFromZero = { startingSpot[0] - 2, startingSpot[1] + 2 };//jump from y

                        int[] outForSeven = { startingSpot[0] - 1, startingSpot[1] - 1 };

                        int[] jumpFromSeven = { startingSpot[0] - 2, startingSpot[1] - 2 };

 

                        #region Player 2 not King

                        if ((yAxis != 0 || yAxis != 7) && gameBoard[xAxis, yAxis] == "p2"){//not on the edge of the board

                            if (wantsToGoHere[0] == outOfBounds[0] && wantsToGoHere[1] >= outOfBounds[1] && wantsToGoHere[1] <= outOfBounds[2]){

                                gameBoard[wantsToGoHere[0], wantsToGoHere[1]] = "p2";

                                gameBoard[startingSpot[0], startingSpot[1]] = " ";

                                makeAChoice = false;

                                break;

                            } else if (wantsToGoHere[0] == makeAJump[0] && (wantsToGoHere[1] == makeAJump[1] || wantsToGoHere[1] == makeAJump[2]) && (gameBoard[currentSpotInArray[0] - 1, currentSpotInArray[1] - 1]) == "p1" || gameBoard[currentSpotInArray[0] - 1, currentSpotInArray[1] + 1] == "p1"){

                                if (gameBoard[currentSpotInArray[0] - 1, currentSpotInArray[1] - 1] == "p1" && wantsToGoHere[1] == makeAJump[1]){

                                    gameBoard[currentSpotInArray[0] - 1, currentSpotInArray[1] - 1] = " ";

                                    gameBoard[startingSpot[0], startingSpot[1]] = " ";

                                    gameBoard[wantsToGoHere[0], wantsToGoHere[1]] = "p2";

                                    makeAChoice = false;

                                } else if (gameBoard[currentSpotInArray[0] - 1, currentSpotInArray[1] + 1] == "p1" && wantsToGoHere[1] == makeAJump[2]){

                                    gameBoard[currentSpotInArray[0] - 1, currentSpotInArray[1] + 1] = " ";

                                    gameBoard[startingSpot[0], startingSpot[1]] = " ";

                                    gameBoard[wantsToGoHere[0], wantsToGoHere[1]] = "p2";

                                    makeAChoice = false;

                                }

                            }

                        } else if (yAxis == 0){//moving from zero can't go left, so its regulated below

 

                            if (wantsToGoHere[0] == outForZero[0] && wantsToGoHere[1] == outForZero[1]){

                                gameBoard[wantsToGoHere[0], wantsToGoHere[1]] = "p2";

                                gameBoard[startingSpot[0], startingSpot[1]] = " ";

                                makeAChoice = false;

                                break;

                            } else if (wantsToGoHere[0] == jumpFromZero[0] && wantsToGoHere[1] == jumpFromZero[1] && gameBoard[currentSpotInArray[0] - 1, currentSpotInArray[1] + 1] == "p1"){

                                gameBoard[wantsToGoHere[0], wantsToGoHere[1]] = "p2";

                                gameBoard[currentSpotInArray[0] + 1, currentSpotInArray[1] + 1] = " ";

                                gameBoard[startingSpot[0], startingSpot[1]] = " ";

                                makeAChoice = false;

                            }//end yAxis = 0

                        } else if (yAxis == 7){

                            if (wantsToGoHere[0] == outForZero[0] && wantsToGoHere[1] == outForZero[1] ){

                                gameBoard[wantsToGoHere[0], wantsToGoHere[1]] = "p2";

                                gameBoard[startingSpot[0], startingSpot[1]] = " ";

                                makeAChoice = false;

                                break;

                            } else if (wantsToGoHere[0] == jumpFromSeven[0] && wantsToGoHere[1] == jumpFromSeven[1] && gameBoard[currentSpotInArray[0] - 1, currentSpotInArray[1] - 1] == "p1"){

                                gameBoard[wantsToGoHere[0], wantsToGoHere[1]] = "p2";

                                gameBoard[currentSpotInArray[0] + 1, currentSpotInArray[1] + 1] = " ";

                                gameBoard[startingSpot[0], startingSpot[1]] = " ";

                                makeAChoice = false;

                            }

                        }

 

                    }//end player2 if

                        #endregion

 

                    #endregion

                }
                
            }

                    string[,] returnBoard = gameBoard;

                    return returnBoard;

        }//end function
        #endregion
    }//End Class
}//End Name