window.onload = () => {
    $(".btn-success").click(() =>
    {
        // исходное слово
        let txt = $("#text-input").val();

        $.ajax({
            url: "/wordTYPE",
            type: "POST",
            data: { word: txt },
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
    });
};