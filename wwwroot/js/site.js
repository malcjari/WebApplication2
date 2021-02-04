$(document).ready(() => {


    onDateClick();




})

function onDateClick() {

    $(".calendar-cell").click(function() {

        let date = $(this).children("#fullDate").val();
        
        $("#modal-body").html(date);


    })


}