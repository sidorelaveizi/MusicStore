
<script type="text/javascript">
    $(document).ready(function () {
        $("#myButton").click(function () {
            $("#myButton").attr("disabled", true);
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '/Cart/Index.cshtml',
                data: '{}',
                //success: function (data) {
                //    alert(data.sessionValue);
                //    if (data.sessionValue == true) {
                //        location.href = "/Home/Demo"
                //    }
                //    else {
                //        location.href = "/Home/Login"
                //    }
                //},
                success: function DisableEnable() {
                    //  $("#myButton").attr('disabled', 'false');
                    if (Session["cart"] == null)
                        $("#myButton").attr('disabled', 'true');

                    else
                        $("#myButton").attr('disabled', 'false');
                    // $("#myButton").removeAttr('disabled');
                },
                error: errorhandler
            });
        })
            }
     </script>