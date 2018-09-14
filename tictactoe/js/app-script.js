//Global variable for current player name
var currentPlayerName = 'X';
//jquery: set text for span name
$('span[name="whoseturn"]').text('X');
//apply highlight/unhighlight css to class player
$('.player[name="X"]').addClass('highlight');
$('.player[name="O"]').addClass('unhighlight');
//on tag td click trigger function
$('td').click(
    function() {
        if(currentPlayerName == 'X'){
            $(this).text('X');
            //set text from X to O
            $('span[name="whoseturn"]').text('O');
            //Switch button highlighting
            $('.player[name="X"]').removeClass('highlight');
            $('.player[name="X"]').addClass('unhighlight');

            $('.player[name="O"]').removeClass('unhighlight');
            $('.player[name="O"]').addClass('highlight');

            currentPlayerName = 'O';
        } else {
            $(this).text('O');
            //set text from X to O
            $('span[name="whoseturn"]').text('X');
            //Switch button highlighting
            $('.player[name="O"]').removeClass('highlight');
            $('.player[name="O"]').addClass('unhighlight');

            $('.player[name="X"]').removeClass('unhighlight');
            $('.player[name="X"]').addClass('highlight');

            currentPlayerName = 'X';
        }
    }
);