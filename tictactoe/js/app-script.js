//Global variable for current player name
var currentPlayerName = 'X';
var rowName;
var columnName;

var gameOver = false;

var gridDimension = 3;

$('span[name="whoseturn"]').text(currentPlayerName);
$('.gameover').hide();

//apply highlight/unhighlight css to class player
$('.player[name="X"]').addClass('highlight');
$('.player[name="O"]').addClass('unhighlight');
//on tag td click trigger function
$('td').click(
    function() {
        if(gameOver){
            return;
        }
        if($(this).text() != ''){
            return;
        }
        if(currentPlayerName == 'X'){
            $(this).text('X');
        } else {
            $(this).text('O');
        }

        rowName = $(this).parent().attr("name");
        columnName = $(this).attr("name");

        if(checkIfCurrentPlayerWon_CheckRow() || checkIfCurrentPlayerWon_CheckColumn()
            || checkIfCurrentPlayerWon_CheckLeftToRightDiagonal()
            || checkIfCurrentPlayerWon_CheckRightToLeftDiagonal()){
            gameOver = true;
            //
            $('.gameover').show();
            $('span[name="whowon"]').text(currentPlayerName);

            return;
        }

        if (currentPlayerName == 'X') {
            //Switch button highlighting
            $('.player[name="X"]').removeClass('highlight');
            $('.player[name="X"]').addClass('unhighlight');

            $('.player[name="O"]').removeClass('unhighlight');
            $('.player[name="O"]').addClass('highlight');

            currentPlayerName = 'O';
            //set text from X to O
            $('span[name="whoseturn"]').text('O');
        } else {
            //Switch button highlighting
            $('.player[name="O"]').removeClass('highlight');
            $('.player[name="O"]').addClass('unhighlight');

            $('.player[name="X"]').removeClass('unhighlight');
            $('.player[name="X"]').addClass('highlight');

            currentPlayerName = 'X';
            //set text from X to O
            $('span[name="whoseturn"]').text('X');
        }
    }
);

function checkIfCurrentPlayerWon_CheckRow() {
    //Select clicked row by name
    var currentRow = $('tr[name="' + rowName + '"]');
    var currentPlayerWon = true;
    //For each row cell, if text doesn't equal current player return false
    currentRow.children().each(function() {
        if($(this).text() != currentPlayerName){
            currentPlayerWon = false;
        }
    });
    return currentPlayerWon;
}

function checkIfCurrentPlayerWon_CheckColumn(){
    var currentPlayerWon = true;
    //for each row by name, if row by name doesn't equal player return false
    $('tr').each(function(){
       var col = $(this).find('td[name=' + columnName +']');
       if(col.text() != currentPlayerName){
           currentPlayerWon = false;
       }
    });
    return currentPlayerWon;
}

function checkIfCurrentPlayerWon_CheckLeftToRightDiagonal() {
    var currentPlayerWon = true;
    //for each row, select cell by row name, if cell text doesn't equal player return false
    $('tr').each(function(){
       var currentRowName = $(this).attr("name");
       var col = $(this).find('td[name=' + currentRowName + ']');
       if(col.text() != currentPlayerName){
           currentPlayerWon = false;
       }
    });
    return currentPlayerWon;
}

function checkIfCurrentPlayerWon_CheckRightToLeftDiagonal(){
    var currentPlayerWon = true;
    //count down + count to left
    var rowNumberColumnNumberTotal = parseInt(rowName) + parseInt(columnName);
        // center cell: row 1 + col 1 = 2 doesn't equal 3 - 1 return false
    if(rowNumberColumnNumberTotal != (gridDimension - 1)){
        return false;
    }

    $('tr').each(function(){
        //For each row
       var currentRowName = $(this).attr("name");
       var currentRowNumber = parseInt(currentRowName);
       //cell 2 - 0 = 2
       var columnNumberToCheck = rowNumberColumnNumberTotal - currentRowNumber;
        //if current selected cell doesn't equal player name return false
       var col = $(this).find('td[name=' + columnNumberToCheck + ']');
       if(col.text() != currentPlayerName){
           currentPlayerWon = false;
       }
    });
    return currentPlayerWon;
}