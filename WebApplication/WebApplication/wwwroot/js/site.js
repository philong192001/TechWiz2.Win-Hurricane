function MatchBooking() {
    let checkboxes = document.getElementsByName('Checkbook');
    var data = [];
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            data.push([checkboxes[i].id])
        }
    }
    console.log(data)
    $.ajax({
        method: "POST",
        url: "/Accounts/Admin/ShareTrip",
        data:
        {
            data: data
        },
        success: function (data) {
            console.log(data)
            //window.location.href = '/Admin';

        }
    });
}

