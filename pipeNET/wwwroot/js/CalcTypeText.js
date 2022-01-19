window.onload = () => {
    $(".btn-success").click(() =>
    {
        let txt = $("#text-input").val();
        let TXTtranslate = $("#text-input").val();

        if (txt !== undefined || txt !== "") {
            $.ajax({
                url: "/Text",
                type: "POST",
                data: { text: txt},
                dataType: 'JSON',
                contentType: 'application/x-www-form-urlencoded',
                success: function (responce) {

                    $("#result").text(responce);

                    $.ajax({
                        url: "/translate",
                        type: "POST",
                        data: { translateTXT: TXTtranslate},
                        dataType: 'JSON',
                        contentType: 'application/x-www-form-urlencoded',
                        success: function (responce) {

                           
                            $("#text-output").text(responce);

                        },
                        error: function (responce) {
                            statusText = "Пустое окно!";
                            alert(`${responce.statusText} StatusCode: ${responce.status}`)
                        }
                        
                });
                },
                error: function (responce) {
                    statusText = "Пустое окно!";
                    alert( `${responce.statusText} StatusCode: ${responce.status}`)
                }
            });
            $("a").click(() => { $("a").removeClass("active") });
        }
    });
};
