function AddDataTable(table) {
    $(document).ready(function () {
        $(table).DataTable({
            pagingType: 'first_last_numbers',
            "dom": 'frtip',
            responsive: true,
            "columnDefs": [
                { "width": "10%", "targets": 0 }
            ],
            retrieve: true
        });
    })
}

function DataTablesDispose(table) {
    $(document).ready(function () {
        $(table).DataTable().destroy();
        var element = document.querySelector(table + '_wrapper');
        element.parentNode.removeChild(element);
    })
}