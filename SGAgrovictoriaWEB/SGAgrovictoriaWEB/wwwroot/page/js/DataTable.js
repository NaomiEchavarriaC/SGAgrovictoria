﻿
$(document).ready(function () {
    var table = new DataTable("#Tabla", {
        language: {
            url: '//cdn.datatables.net/plug-ins/2.0.2/i18n/es-ES.json'
        },
        columnDefs: [{ type: 'string', target: [0] }]
    });
});