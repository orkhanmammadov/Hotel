$(document).ready(function(){

    $("#dashboard form").submit(function(e){
        e.preventDefault();
        $("#dashboard table").slideDown();
    });

    $("#room .header button").click(function(){
        $("#room .room-list").hide();
        $("#room .create").show();
        $("#room .header h1").text("Create Room");
        $("#room .header .btn-primary").show();
    });

    // $("#room .header .btn-primary").click(function(){
    //     $("#room .room-list").show();
    //     $("#room .create").hide();
    // });

    $("#customer .header button").click(function(){
        $("#customer .customer-list").hide();
        $("#customer .create").show();
        $("#customer .header h1").text("Create");
        $("#customer .header .btn-primary").show();
    });


    $("#room .room-list .btn-status").click(function(){
        $(this).toggleClass("active");
        if($(this).hasClass("active")){
            $(this).text("Active");
        }else{
            $(this).text("Deactive");
        }
        
    });

    $(".search-room").click(function () {

        console.log("aza");
        var chechIn = $(".checkin");
        var checkOut = $(".checkout");

        var person = $(".person:selected");
        var child = $(".child:selected");
        var search = {};
        search = { CheckIn: chechIn.text(), CheckOut: checkOut.text(), Person: person.text(), Child: child.text() };


        $.ajax({
            url: "/reception/SearchInSearch?search=" + search,
            type: "get",
            dataType: "html",
            success: function (response) {
                $(".dataTable").empty();
                $(".dataTable").append(response);
            },
            error: function (error) {
                console.log(error);
            }
        });
    });

    $("#customer .customer-list .btn-status").click(function(){
        $(this).toggleClass("active");
        if($(this).hasClass("active")){
            $(this).text("Active");
        }else{
            $(this).text("Deactive");
        }
        
    })

});