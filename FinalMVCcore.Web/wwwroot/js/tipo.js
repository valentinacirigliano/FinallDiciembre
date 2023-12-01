var tablaTipoDePlantas;
$(document).ready(function () {
    tablaTipoDePlantas = $('#tblTipos').DataTable({
        "ajax": {
            "url": "/TipoDePlanta/GetAll"
        },
        "columns": [

            { "data": "descripcion" },
            {
                "data": "tipoPlantaId",
                "render": function (data) {
                    return `
                                <a class="btn btn-warning" href="/TipoDePlanta/UpSert?id=${data}" >
                                    <i class="bi bi-pencil-square"></i>&nbsp;
                                    Editar
                                </a>
                                <a class="btn btn-danger" onclick="Delete('/TipoDePlanta/Delete/${data}')" >
                                    <i class="bi bi-trash3"></i> &nbsp;
                                    Eliminar
                                </a>

                            `
                }
            }
        ]
        
    });

});



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
                        tablaTipoDePlantas.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });


}
