window.ShowToastr = (type, message) => {
    if (type == "success") {
        toastr.success(message, "Operation Succesfully");
    }
    if (type == "error") {
        toastr.error(message, "Operation Failed");
    }
 
}

function AddDataTable(table) {
    $(document).ready(function () {
        $(table).DataTable();
    })
}
function DataTableDispose(table) {
    $(document).ready(function () {
        $(table).DataTable().destroy();
        var element = document.querySelector(table + '_wrapper');
        element.parentNode.removeChild(element);

    })
}

function ConfirmSweetAlert(title, text) {
    swal({
        title: title,
        text: text,
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                return true;
            } else {
                return false;
            }
        });
}

function printContent(el) {
    var restorepage = $('body').html();
    var printcontent = $('#' + el).clone();
    $('body').empty().html(printcontent);
    window.print();
    location.reload();

   /* $('body').html(restorepage);*/

}

function BlazorDownloadFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}

function printDocument(data,type) {


    $("#pdf_files").html("");

            if (type == '.pdf')
                var htmlPop = '<iframe id="iframe" src="data:application/pdf;base64,' + data + '"  width="1095" height="1200" allowfullscreen webkitallowfullscreen disableprint=true; ></iframe>';
            else
                var htmlPop = '<embed width="1150" height="1200" src="data:image/png;base64,' + data + '"></embed>';

            $("#pdf_files").html(htmlPop);
            $('#print-view-modal').modal('show');


        
  
};