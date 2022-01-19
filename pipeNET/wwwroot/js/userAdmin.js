window.onload = () => {
    $(".btn-outline-danger").click(() =>
    {

        let txt = event.target.id;
        let func = event.target.name;

        if (func == "del") {
            $.ajax({
                url: "/DeleteUser",
                type: "POST",
                data: { username: txt },
                dataType: 'JSON',
                contentType: 'application/x-www-form-urlencoded',
                success: function (responce) {

                    $("#result").text(responce);
                    alert("успешно");
                    location.reload();
                },
                error: function (responce) {
                    if (responce.status == 1) alert("Поле пустое! " + `${responce.statusText} StatusCode: ${responce.status}`);
                    else alert("Неизвестная ошибка " + `${responce.statusText} StatusCode: ${responce.status}`);
                    $("#repeat").click();
                }
            });
        }
        if (func == "ban") {

            let roleuser = "ban";

            $.ajax({
                url: "/AddUserRole",
                type: "POST",
                data: { name: txt, role: roleuser },
                dataType: 'JSON',
                contentType: 'application/x-www-form-urlencoded',
                success: function (responce) {

                    $("#result").text(responce);
                    alert("успешно");
                    location.reload();
                },
                error: function (responce) {
                    if (responce.status == 1) alert("Поле пустое! " + `${responce.statusText} StatusCode: ${responce.status}`);
                    else alert("Неизвестная ошибка " + `${responce.statusText} StatusCode: ${responce.status}`);
                    $("#repeat").click();
                }
            });
        }
        else {
            let roleuser = "def";

            $.ajax({
                url: "/DelUserRole",
                type: "POST",
                data: { name: txt, role: roleuser },
                dataType: 'JSON',
                contentType: 'application/x-www-form-urlencoded',
                success: function (responce) {

                    $("#result").text(responce);
                    alert("успешно");
                    location.reload();
                },
                error: function (responce) {
                    if (responce.status == 1) alert("Поле пустое! " + `${responce.statusText} StatusCode: ${responce.status}`);
                    else alert("Неизвестная ошибка " + `${responce.statusText} StatusCode: ${responce.status}`);
                    $("#repeat").click();
                }
            });
        }
    });

    $(".btn-success").click(() => {

        let txt = event.target.id;
        let roleuser = event.target.name;

        $.ajax({
            url: "/AddUserRole",
            type: "POST",
            data: { name: txt, role: roleuser },
            dataType: 'JSON',
            contentType: 'application/x-www-form-urlencoded',
            success: function (responce) {

                $("#result").text(responce);
                alert("успешно");
                location.reload();
            },
            error: function (responce) {
                if (responce.status == 1) alert("Поле пустое! " + `${responce.statusText} StatusCode: ${responce.status}`);
                else alert("Неизвестная ошибка " + `${responce.statusText} StatusCode: ${responce.status}`);
                $("#repeat").click();
            }
        });

    });

    $(".btn-warning").click(() => {

        let txt = event.target.id;
        let roleuser = event.target.name;

        $.ajax({
            url: "/DelUserRole",
            type: "POST",
            data: { name: txt, role: roleuser},
            dataType: 'JSON',
            contentType: 'application/x-www-form-urlencoded',
            success: function (responce) {

                $("#result").text(responce);
                alert("успешно");
                location.reload();
            },
            error: function (responce) {
                if (responce.status == 1) alert("Поле пустое! " + `${responce.statusText} StatusCode: ${responce.status}`);
                else alert("Неизвестная ошибка " + `${responce.statusText} StatusCode: ${responce.status}`);
                $("#repeat").click();
            }
        });

    });
};