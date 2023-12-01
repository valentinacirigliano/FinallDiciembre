var tablaPlantas;
$(document).ready(function () {
    tablaPlantas = $('#tblPlantas').DataTable({
        "ajax": {
            "url": "/Planta/GetAll"
        },
        "columns": [

            { "data": "descripcion" },
            { "data": "tipoDePlanta" },
            { "data": "precio" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                                <a class="btn btn-warning" href="/Planta/UpSert?id=${data}" >
                                    <i class="bi bi-pencil-square"></i>&nbsp;
                                    Editar
                                </a>
                                <a class="btn btn-danger" onclick="Delete('/Planta/Delete/${data}')" >
                                    <i class="bi bi-trash3"></i> &nbsp;
                                    Eliminar
                                </a>

                            `
                }
            }
        ]
        ,
        "initComplete": function () {
            // Agregar el control de selección y ordenación
            var selectOrden = $('<select id="selectOrden" class="form-select form-select-sm"></select>')
                .appendTo($('#tblPlantas_wrapper .dataTables_length'))
                .on('change', function () {
                    var selectedValue = $(this).val();
                    var columnIndex = getColumnIndexByTitle(selectedValue);
                    if (columnIndex !== -1) {
                        tablaPlantas.order([columnIndex, 'asc']).draw();
                    }
                });

            $('#tblPlantas thead th').each(function () {
                var title = $(this).text();
                selectOrden.append('<option value="' + title + '">' + title + '</option>');
            });
            // Agregar label personalizado
            selectOrden.wrap('<div class="input-group"></div>').parent().prepend('<div class="input-group-prepend"><span class="input-group-text">Ordenar por:</span></div>');
        }
    });

});

// Función para obtener el índice de columna según el título
function getColumnIndexByTitle(title) {
    var columnIndex = -1;
    $('#tblPlantas thead th:lt(3)').each(function (index) {
        if ($(this).text() === title) {
            columnIndex = index;
            return false;
        }
    });
    return columnIndex;
}

function Delete(url) {
    Swal.fire({
        title: '¿Estás seguro?',
        text: "¡No podrás revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí, eliminarlo'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                "url": url,
                "type": 'DELETE',
                "success": function (data) {
                    console.log(data);
                    if (data.success) {
                        tablaPlantas.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });


}
