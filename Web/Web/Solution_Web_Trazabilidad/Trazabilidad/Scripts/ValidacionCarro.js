$("#formulario").submit(function () {
    if ($("Descripcion").val().length < 20) {
        alert("El nombre debe tener como mínimo 20 caracteres");
        return false;
    }
    //alert("paso");
    
    return true;
});