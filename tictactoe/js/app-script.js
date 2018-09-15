//Global variable for current player name
var currentPlayerName = 'X';
var rowName;
var columnName;

var gameOver = false;

$('span[name="whoseturn"]').text(currentPlayerName);
$('.gameover').hide();

//apply highlight/unhighlight css to class player
$('.player[name="X"]').addClass('highlight');
$('.player[name="O"]').addClass('unhighlight');
//on tag td click trigger function
$('td').click(
    function() {
        if(currentPlayerName == 'X'){
            $(this).text('X');
        } else {
            $(this).text('O');
        }
        rowName = $(this).parent().attr("name");
        columnName = $(this).attr("name");
        if(checkIfCurrentPlayerWon_CheckRow() || checkIfCurrentPlayerWon_CheckColumn()){
            gameOver = true;
            //
            $('.gameover').show();
            $('span[name="whowon"]').text(currentPlayerName);
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
    var currentRow = $('tr[name="' + rowName +'"');
    var currentPlayerWon = true;
    currentRow.children().each(function(){
        if($(this).text() != currentPlayerName){
            currentPlayerWon = false;
        }
    });
    return currentPlayerWon;
}

function checkIfCurrentPlayerWon_CheckColumn(){
    var currentPlayerWon = true;
    $('tr').each(function(){
       var col = $(this).find('td[name=' + columnName +']');
       if(col.text() != currentPlayerName){
           currentPlayerWon = false;
       }
    });
    return currentPlayerWon;
}