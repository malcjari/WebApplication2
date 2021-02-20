$(document).ready(function() {


    
   // onAddClick();


})

function onDateClick() {

    $(".calendar-cell").click(function() {

        let date = $(this).children("#fullDate").val();
        
        $("#modal-body").html(date);

    })


}

function onAddClick() {

    $("#addBtn").click(function(e) {
        console.log('trigg')
        e.preventDefault();

        let date = $("#dateSelect").val
        let shift = $('#shiftSelect').val
        let task = $('#taskSelect').val

        $.post("Home/Add",
            {
                "Date": date,
                "Task": task,
                "Shift": shift
            },
            function (data) {

        })
    })
}

function onDateClick2() {

    $(".calendar-cell").click(function (e) {

        console.log(e.currentTarget)
    })


}