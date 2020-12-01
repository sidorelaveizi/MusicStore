<script>
    $(document).ready(function() {
        DisableEnable = function () {
            if (Session["cart"] == null) {
                $("#myButton").attr('disabled', 'true')
            }
            else {
                $("#myButton").attr('disabled', 'false')
            }
        }
        
    });
</script>


