/*
bu kısımda katagori tablosunu ekle butonu ile veri ekleme işlemi yaptık
*/
$(document).on("click", ".ktgEkle", async function () {
    const { value: formValues } = await Swal.fire({
        title: 'Kategori Ekle',
        html:  '<input id="ktgAd" class="swal2-input">'
    })

    if (formValues) {
        var ktgAd = $("#ktgAd").val();
        $.ajax({
            type: 'post',
            url: '/Kategori/EkleJson',
            data: { "ktgAd": ktgAd },
            dataType: 'Json', 
            success: function (data) {

                var ktgId = data.Result.Id;
                var ktgAd = '<td>' + data.Result.Ad + '</td>';
                var guncelleButon = "<button value='" + ktgId + "' class='guncelle' style='background-color: #009DF1; color: white'> Güncelle</button > ";
                var silButon = "<button value='" + ktgId + "' class='sil' style='background-color: red; color: white'> sil</button > ";
                var kitapAdet = "<td>0</td>"

                $("#example tbody").prepend('<tr>' + ktgId + ktgAd + kitapAdet + guncelleButon + silButon + '</tr>');

                Swal.fire({
                    type: 'success',
                    title: 'Kategori Eklendi',
                    Text: 'işlem Başarıyla Gerçekleştirildi'
                });
            },
            error: function () {
         
                Swal.fire({
                    type: 'error',
                    title: 'Kategori Eklenemedi',
                    Text: 'işlem Başarıyla Gerçekleştirilemedi!'
                });
            }
        });
    }
});


/*
bu kısımda katagori tablosunu güncelle butonu ile veri günecelleme işlemi yaptık
*/
$(document).on("click", ".guncelle", async function () {
    var ktgId = $(this).val();
    var ktgAdTd = $(this).parent("td").parent("tr").find("td:first");
    var ktgAd = ktgAdTd.html();

    const { value: formValues } = await Swal.fire({
        title: 'Kategori güncelle',
        html: '<input id="ktgAd" value="' + ktgAdTd.html() + '" class="swal2-input">'
    })

    ktgAd = $("#ktgAd").val();

        $.ajax({
            type: 'post',
            url: '/Kategori/GüncelleJson',
            data: { "ktgId": ktgId , "ktgAd": ktgAd },
            dataType: 'Json',
            success: function (data) {

                if (data == "1") {
                    ktgAdTd.html(ktgAdTd.html());
                    Swal.fire({
                        type: 'success',
                        title: 'Kategori Güncellendi',
                        Text: 'işlem Başarıyla Gerçekleştirildi'
                    });
                }
                else {
                    Swal.fire({
                        type: 'error',
                        title: 'Kategori Güncellenemedi',
                        Text: 'işlem Başarıyla Gerçekleştirilemedi!'
                    });
                }
            },
            error: function () {

                Swal.fire({
                    type: 'error',
                    title: 'Kategori Güncellenemedi',
                    Text: 'işlem Başarıyla Gerçekleştirilemedi!'
                });
            }
        });

});


/*
bu kısımda katagori tablosunu sil butonu ile veri silme işlemi yaptık
*/
$(document).on("click", ".sil", async function () {
    var ktgId = $(this).val();
    var tr = $(this).parent("td").parent("tr");

    $.ajax({
        type: 'post',
        url: '/Kategori/SilJson',
        data: { "ktgId": ktgId },
        dataType: 'Json',
        success: function (data) {

            if (data == "1") {
                tr.remove();
                Swal.fire({
                    type: 'success',
                    title: 'Kategori Silindi',
                    Text: 'işlem Başarıyla Gerçekleştirildi'
                });
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'Kategori Silinemedi',
                    Text: 'işlem Başarıyla Gerçekleştirilemedi!'
                });
            }

        },
        error: function () {

            Swal.fire({
                type: 'error',
                title: 'Kategori Güncellenemedi',
                Text: 'işlem Başarıyla Gerçekleştirilemedi!'
            });
        }

    });



});


/*
bu kısımda yazar tablosunu ekle butonu ile veri ekleme işlemi yaptık
*/
$(document).on("click", ".yazarEkle", async function () {
    const { value: formValues } = await Swal.fire({
        title: 'Yazar Ekle',
        html: '<input id="yzrAd" class="swal2-input">'
    })

    if (formValues) {
        var yzrAd = $("#yzrAd").val();
        $.ajax({
            type: 'post',
            url: '/Yazar/EkleJson',
            data: { "yzrAd": yzrAd },
            dataType: 'Json',
            success: function (data) {

                var yzrId = data.Result.Id;
                var yzrAd = '<td>' + data.Result.Ad + '</td>';
                var guncelleButon = "<button value='" + yzrId + "' class='guncelle' style='background-color: #009DF1; color: white'> Güncelle</button > ";
                var silButon = "<button value='" + yzrId + "' class='sil' style='background-color: red; color: white'> sil</button > ";
                var kitapAdet = "<td>0</td>"

                $("#example tbody").prepend('<tr>' + yzrId + yzrAd + kitapAdet + guncelleButon + silButon + '</tr>');

                Swal.fire({
                    type: 'success',
                    title: 'Yazar Eklendi',
                    Text: 'işlem Başarıyla Gerçekleştirildi'
                });
            },
            error: function () {

                Swal.fire({
                    type: 'error',
                    title: 'Yazar Eklenemedi',
                    Text: 'işlem Başarıyla Gerçekleştirilemedi!'
                });
            }

        });
    }
});


/*
bu kısımda yazar tablosunu güncelle butonu ile veri günecelleme işlemi yaptık
*/
$(document).on("click", ".yzr_guncelle", async function () {
    var yzrId = $(this).val();
    var yzrAdTd = $(this).parent("td").parent("tr").find("td:first");
    var yzrAd = yzrAdTd.html();

    const { value: formValues } = await Swal.fire({
        title: 'Yazar güncelle',
        html: '<input id="yzrAd" value="' + yzrAdTd.html() + '" class="swal2-input">'
    })

    yzrAd = $("#yzrAd").val();

    $.ajax({
        type: 'post',
        url: '/Yazar/GüncelleYzrJson',
        data: { "yzrId": yzrId, "yzrAd": yzrAd },
        dataType: 'Json',
        success: function (data) {

            if (data == "1") {
                yzrAdTd.html(yzrAdTd.html());
                Swal.fire({
                    type: 'success',
                    title: 'Yazar Güncellendi',
                    Text: 'işlem Başarıyla Gerçekleştirildi'
                });
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'Yazar Güncellenemedi',
                    Text: 'işlem Başarıyla Gerçekleştirilemedi!'
                });
            }

        },
        error: function () {

            Swal.fire({
                type: 'error',
                title: 'Yazar Güncellenemedi',
                Text: 'işlem Başarıyla Gerçekleştirilemedi!'
            });
        }

    });

});


/*
bu kısımda yazar tablosunu sil butonu ile veri silme işlemi yaptık
*/
$(document).on("click", ".yzr_sil", async function () {
    var yzrId = $(this).val();
    var tr = $(this).parent("td").parent("tr");

    $.ajax({
        type: 'post',
        url: '/Yazar/SilYzrJson',
        data: { "yzrId": yzrId },
        dataType: 'Json',
        success: function (data) {

            if (data == "1") {
                tr.remove();
                Swal.fire({
                    type: 'success',
                    title: 'Yazar Silindi',
                    Text: 'işlem Başarıyla Gerçekleştirildi'
                });
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'Yazar Silinemedi',
                    Text: 'işlem Başarıyla Gerçekleştirilemedi!'
                });
            }

        },
        error: function () {

            Swal.fire({
                type: 'error',
                title: 'Yazar Silinemedi',
                Text: 'işlem Başarıyla Gerçekleştirilemedi!'
            });
        }

    });
});


/*
kitap listesine kaydet butonu ile ekleme
*/
$(document).on("click", "#kitapKaydet", function () {
    var degerler = {
        Kategoriler : $("#kategoriler option:selected").attr("data-id"),
        Yazar : $("#yazar option:selected").attr("data-id"),
        KitapAd : $("#kitapAd").val(),
        KitapAdet : $("#kitapAdet").val(),
        SiraNo : $("#siraNo").val()  
    }; 

    $.ajax({
        type: 'post',
        url: '/Kitap/EkleKtpJson',
        data: JSON.stringify(degerler),
        dataType: 'Json',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {

            if (gelenDeg == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Kitap Eklendi',
                    Text: 'işlem Başarıyla Gerçekleştirildi!'
                });
            }
            else if("bosOlamaz")
            {
                Swal.fire({
                    type: 'error',
                    title: 'Kitap Eklenemedi',
                    Text: 'Boş Alanları Lütfen Doldurun'
                });
            }
            
        },
        error: function () {

            Swal.fire({
                type: 'error',
                title: 'Kitap Eklenemedi',
                Text: 'işlem Başarıyla Gerçekleştirilemedi!'
            });
        }
    });
});


/*
kitap listesine güncelle butonu ile güncelleme
*/
$(document).on("click", "#kitapGüncelle", function () {
    var degerler = {
        Kategoriler: $("#kategoriler option:selected").attr("data-id"),
        Yazar: $("#yazar option:selected").attr("data-id"),
        KitapAd: $("#kitapAd").val(),
        KitapAdet: $("#kitapAdet").val(),
        SiraNo: $("#siraNo").val(),
        kitapId: $(this).attr("data-id")
    };

    $.ajax({
        type: 'post',
        url: '/Kitap/GüncelleKtpJson',
        data: JSON.stringify(degerler),
        dataType: 'Json',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {

            if (gelenDeg == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Kitap Güncellendi',
                    Text: 'işlem Başarıyla Gerçekleştirildi!'
                });
            }
            else if ("bosOlamaz") {
                Swal.fire({
                    type: 'error',
                    title: 'Kitap Güncellenmedi',
                    Text: 'Boş Alanları Lütfen Doldurun'
                });
            }

        },
        error: function () {

            Swal.fire({
                type: 'error',
                title: 'Kitap Güncellenmedi',
                Text: 'işlem Başarıyla Gerçekleştirilemedi!'
            });
        }
    });
});


/*
kitap listesine  silme
*/
$(document).on("click", ".ktp_sil",  function () {

    Swal.fire({
        title: 'Emin misin?',
        text: "Bunu geri alamazsınız!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, silin!',
    }).then((result) => {
        if (result.isConfirmed) {
            var kitapId = $(this).val();
            var tr = $(this).parent("td").parent("tr");

            $.ajax({
                type: 'post',
                url: '/Kitap/SilKtpJson',
                data: { "kitapId": kitapId },
                dataType: 'Json',
                success: function (data) {

                    if (data == "1") {
                        tr.remove();
                        Swal.fire({
                            type: 'success',
                            title: 'Kitap Silindi',
                            Text: 'işlem Başarıyla Gerçekleştirildi'
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'Kitap Silinemedi',
                            Text: 'işlem Başarıyla Gerçekleştirilemedi!'
                        });
                    }
                },
                error: function () {

                    Swal.fire({
                        type: 'error',
                        title: 'Kitap Silinemedi',
                        Text: 'işlem Başarıyla Gerçekleştirilemedi!'
                    });
                }
            });
        }
    })
});


/*
Uye listesine kaydet butonu ile ekleme
*/
$(document).on("click", "#uyeKaydet", function () {
    var degerler = {
        uyeAd: $("#Ad").val(),
        uyeSoyad: $("#Soyad").val(),
        uyeTc: $("#Tc").val(),
        uyeTel: $("#Tel").val(),
    };

    $.ajax({
        type: 'post',
        url: '/Uye/EkleUyeJson',
        data: JSON.stringify(degerler),
        dataType: 'Json',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {

            if (gelenDeg == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Uye Eklendi',
                    Text: 'işlem Başarıyla Gerçekleştirildi!'
                });
            }
            else if ("bosOlamaz") {
                Swal.fire({
                    type: 'error',
                    title: 'Uye Eklenemedi',
                    Text: 'Boş Alanları Lütfen Doldurun'
                });
            }

        },
        error: function () {

            Swal.fire({
                type: 'error',
                title: 'Uye Eklenemedi',
                Text: 'işlem Başarıyla Gerçekleştirilemedi!'
            });
        }
    });
});


/*Uye listesine güncelle butonu ile güncelleme
*/
$(document).on("click", "#uyeGüncelle", function () {
    var degerler = {

        uyeAd: $("#Ad").val(),
        uyeSoyad: $("#Soyad").val(),
        uyeTc: $("#Tc").val(),
        uyeTel: $("#Tel").val(),
        uyeId: $(this).attr("data-id")
    };

    $.ajax({
        type: 'post',
        url: '/Uye/GüncelleUyeJson',
        data: JSON.stringify(degerler),
        dataType: 'Json',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {

            if (gelenDeg == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Üye Güncellendi',
                    Text: 'işlem Başarıyla Gerçekleştirildi!'
                });
            }
            else if ("bosOlamaz") {
                Swal.fire({
                    type: 'error',
                    title: 'Üye Güncellenmedi',
                    Text: 'Boş Alanları Lütfen Doldurun'
                });
            }

        },
        error: function () {

            Swal.fire({
                type: 'error',
                title: 'Üye Güncellenmedi',
                Text: 'işlem Başarıyla Gerçekleştirilemedi!'
            });
        }
    });
});


/*
uye listesine  silme
*/
$(document).on("click", ".uye_sil", function () {

    Swal.fire({
        title: 'Emin misin?',
        text: "Bunu geri alamazsınız!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, silin!',
    }).then((result) => {
        if (result.isConfirmed) {
            var uyeId = $(this).val();
            var tr = $(this).parent("td").parent("tr");

            $.ajax({
                type: 'post',
                url: '/Uye/SilUyeJson',
                data: { "uyeId": uyeId },
                dataType: 'Json',
                success: function (data) {

                    if (data == "1") {
                        tr.remove();
                        Swal.fire({
                            type: 'success',
                            title: 'Uye Silindi',
                            Text: 'işlem Başarıyla Gerçekleştirildi'
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'Uye Silinemedi',
                            Text: 'işlem Başarıyla Gerçekleştirilemedi!'
                        });
                    }
                },
                error: function () {

                    Swal.fire({
                        type: 'error',
                        title: 'Uye Güncellenemedi',
                        Text: 'işlem Başarıyla Gerçekleştirilemedi!'
                    });
                }
            });
        }
    })
});


/*
OduncKitap içindeki VerilenKitap kitap ver butonu ile kitap ekleme
*/
$(document).on("click", "#kitapVer", function () {
    var degerler = {
        uyeId: $("#uyeId option:selected").attr("data-id"),
        getirecegiTarih: $("#getirecegiTarih").val()
    };

    $.ajax({
        type: 'post',
        url: '/OduncKitap/KitapVerJson',
        data: JSON.stringify(degerler),
        dataType: 'Json',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {

            if (gelenDeg == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Kitap Verildi',
                    Text: 'işlem Başarıyla Gerçekleştirildi!'
                });
            }
            else {
                Swal.fire({
                    type: 'success',
                    title: 'Kitap Verilemedi',
                    Text: 'Veri Tabanına Eklenirken Bir Sorun İle Karşılaşıldı!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Kitap Verilemedi',
                Text: 'işlem Başarıyla Gerçekleştirilemedi!'
            });
        }
    });
});


/*
Kitap Teslim Edildi Olarak işaretleme
*/
$(document).on("click", ".odnc_sil", function () {

    Swal.fire({
        title: 'Emin misin?',
        text: "Bunu geri alamazsınız!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet!',
    }).then((result) => {
        if (result.isConfirmed) {
            var oduncKtpId = $(this).val();
            var tr = $(this).parent("td").parent("tr");

            $.ajax({
                type: 'post',
                url: '/OduncKitap/GetırdIsaretleJson',
                data: { "oduncKtpId": oduncKtpId },
                dataType: 'Json',
                success: function (data) {

                    if (data == "1") {
                        tr.remove();
                        Swal.fire({
                            type: 'success',
                            title: 'Kitap Getirildi Olarak İşaretlendi',
                            Text: 'işlem Başarıyla Gerçekleştirildi'
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'Kitap Getirildi Olarak İşaretlenemedi',
                            Text: 'işlem Başarıyla Gerçekleştirilemedi!'
                        });
                    }
                },
                error: function () {

                    Swal.fire({
                        type: 'error',
                        title: 'Kitap Getirildi Olarak İşaretlenemedi',
                        Text: 'işlem Başarıyla Gerçekleştirilemedi!'
                    });
                }
            });
        }
    })
});


/*
Üyelik işlemleri Üye ekle
*/
$(document).on("click", "#uyelikEkle", function () {
    var uyeId = $("#uyeId").val();
    var Mail = $("#Mail").val();
    var parola = $("#parola").val();
    var parolaTekrar = $("#parolaTekrar").val();
    

    $.ajax({
        type: 'post',
        url: '/Uyelik/EkleUyelikJson',
        data: { 'uyeId': uyeId, 'Mail': Mail, 'parola': parola, 'parolaTekrar': parolaTekrar},
        dataType: 'Json',
        success: function (gelenDeg) {

            if (gelenDeg == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Üyelik Oluştu',
                    Text: 'işlem Başarıyla Gerçekleştirildi!'
                });
            }
            else if (gelenDeg == "bosOlamaz") {
                Swal.fire({
                    type: 'error',
                    title: 'Üyelik Oluşturulamadı',
                    Text: 'Boş Alanları Lütfen Doldurun'
                });
            }
            else if (gelenDeg == "parolaUyusmazligi") {
                Swal.fire({
                    type: 'error',
                    title: 'Parola Uyuşmuyor',
                    Text: 'Parolalar Birbiri İle Uyuşmadı'
                });
            }

        },
        error: function () {

            Swal.fire({
                type: 'error',
                title: 'Üyelik Oluşturulamadı',
                Text: 'işlem Başarıyla Gerçekleştirilemedi!'
            });
        }
    });
});
