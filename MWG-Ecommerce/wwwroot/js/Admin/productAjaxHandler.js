
showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');
        },
        error: function (er) {
            console.log(er.responseText);
        }

    })
}


ajaxPostProduct = form => {
    try {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res === "Thêm sản phẩm thành công!") {
                    window.location.reload();
                } else {
                    $("#form-modal .modal-body").html(res);
                }

            },
            error: function (er) {
                //console.log(er.responseText);
            }

        })
    } catch (e) {
        console.log(e)
    }
    return false
}



ajaxDeleteProduct = form => {
    
    if (confirm(`Bạn chắc chắn muốn xóa sản phẩm này không ?`))
        try {
            $.ajax({
                type: "POST",
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res === "Xóa sản phẩm thành công!") {
                        window.location.reload();
                    } else {
                        alert(res)
                    }

                },
                error: function (er) {
                    //console.log(er.responseText);
                }

            })
        } catch (e) {
            console.log(e)
        }
    return false
}