function MatchBooking() {
    let checkboxes = document.getElementsByName('Checkbook');
    var data = [];
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            data.push([checkboxes[i].id])
        }
    }
    if (data.length < 2) {
        swal({

            text: "No invalid ",
            icon: "error",
        });
        return;
    }
    
 

    $.ajax({
        method: "POST",
        url: "/Accounts/Admin/ShareTrip",
        data:
        {
            data: data,

        },
        success: function (data) {
            if (data === "false") {
                swal({
                    
                    text: "No cars with enough seats",
                    icon: "error",
                });


            } else {

                swal({
                    title: "Success",
                    icon: "success",
                    timer: 9000
                });
                setTimeout(function () {

                   
                }, 3000);

            }

        }
    });  
}
function NotiSubmitBook() {
    swal({

        text: "Booking success ",
        icon: "success",
    });
}
   


