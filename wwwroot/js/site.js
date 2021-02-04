$(document).ready(() => {


    $(".modal").click(function () {
        $("#myModal").modal({
            backdrop: 'static',
            keyboard: false
        });
    });

    



})

function onDateClick() {

    $(".calendar-cell").click(function() {

        let date = $(this).children("#fullDate").val();
        
        $("#modal-body").html(date);

    })


}

function onDateClick2() {

    $(".calendar-cell").click(function (e) {

        console.log(e.currentTarget)
    })


}