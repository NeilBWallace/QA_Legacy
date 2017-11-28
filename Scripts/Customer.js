$(document).ready(function () {


    
    
    
   



    $("#MainContent_txtCountry").autocomplete({
       
        source: function (request, response) {
            var param = { keyword: $('#MainContent_txtCountry').val() };
            $.ajax({
                url: "Default.aspx/GetCountryNames",
                data: JSON.stringify(param),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            value: item
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                 
                }
            });
        },
        select: function (event, ui) {
            
            if (ui.item) {
                GetCustomerDetails(ui.item.value);
            }
        },
        minLength: 3
    });
});


function GetCustomerDetails(country) {
   ;
    $("#tblCustomers tbody tr").remove();

    $.ajax({
        type: "POST",
        url: "Default.aspx/GetCustomers",
        data: '{person_name: "' + country + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            response($.map(data.d, function (item) {
                var rows = "<tr>"
                    + "<td class='customertd'>" + item.person_code + "</td>"
                           + "</tr>";
                $('#tblCustomers tbody').append(rows);
            }))
        },
     
    });
}