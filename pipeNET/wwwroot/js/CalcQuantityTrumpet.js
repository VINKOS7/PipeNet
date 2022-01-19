window.onload = () => {
    $(".btn-success").click(() =>
    {
        let filename = event.target.id;

        if (filename != "restart") {
            $.ajax({
                url: "/CalcTump",
                type: "POST",
                data: { file: filename },
                dataType: 'JSON',
                contentType: 'application/x-www-form-urlencoded',
                success: function (responce) {

                    $("#result").text(responce);

                },
                error: function (responce) {
                    if (responce.status == 1) alert("Поле пустое! " + `${responce.statusText} StatusCode: ${responce.status}`);
                    else alert("Неизвестная ошибка " + `${responce.statusText} StatusCode: ${responce.status}`);
                    $("#repeat").click();
                }
            });
            $("a").click(() => { $("a").removeClass("active") });
        }
    });

    $(".btn-light").change(() => {
        $('form').submit();
    });
};