$('#btn_api_submit1').click(function () {
    var endDateVal = $("#FinishDate").val()
    var startDateVal = $("#StartDate").val()
    var url = "?startDate=" + startDateVal + "&finishDate=" + endDateVal;

    //get data from inputs and add to query
    $.ajax({
        type: 'Get',
        url: '/api/driverApi/get' + url,
        success: function (order) {
            var result = '';
           
            result += '<table class="table"><tr><th>Номер </th><th>Дата: </th><th>Начальное время </th>' +
                +'<th>Конечное время </th><th>Адрес отправки </th><th>Адрес доставки </th>' +
                +'<th>Машина: </th><th></th><th>Категория </th><th>Заказ выполнен  </th><th>Телефон клиента</th></tr>';

            for (var item in order) {
                result += '<tr<td>' + item.Number + '</td><td>' + item.Date + '</td><td>' +
                    +item.StartTime + '</td><td>' + item.FinishTime + '</td><td>' + item.StartAdress + '</td><td>' +
                    +item.FinishAdress + '</td><td>' + item.Car + '</td><td>' + item.Carcategory + '</td><td>' +
                    +item.IsDone + '</td><td>'+item.ClientPhone+'</td></tr>'
            };
            $('.list-container').empty().append(result);
            window.location = apiUrl + originalReqIdentifier;
        },
        error: function (msg) {
            alert('Server error', msg);
        }
        
    })
});
//<script>
//    $(document).ready(function () {
//        $("#btnDownload").click(function () {
//            var apiUrl = "../api/DownloadExcel/ExportExcelFile?OriginalRequestNumber=";
//            var originalReqIdentifier = $('#OriginalRequestNumber').val();
//            $.ajax({
//                url: apiUrl + originalReqIdentifier,
//                type: 'GET',
//                dataType: 'json',
//                success: function (data) {
//                    alert(data);
//                },
//                error: function (data) {
//                    window.location = apiUrl + originalReqIdentifier;
//                }
//            });
//        });
//});
//</script>
