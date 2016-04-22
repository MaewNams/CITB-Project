﻿BaseURL = window.location.origin;
$(document).ready(function () {


    var ospry = new Ospry('pk-test-mm3nyd399te4tplr3ewv29n3');

    $('#up-form').submit(function (e) {
        e.preventDefault();
        ospry.up({
            form: this,
            imageReady: function (err, metadata, i) {
                if (err === null) {
                    console.log('Image uploaded to: ' + metadata.url);
                    var picurl = metadata.url;
                    $("#target-pic").text(picurl);
                }
            },
        });
    });


    $(function () {
        CKEDITOR.replace('editor',
         {
             customConfig: '/Scripts/ckeditor/config.js'
         });
    });

    $(function () {
        CKEDITOR.replace('editor2',
         {
             customConfig: '/Scripts/ckeditor/config.js'
         });
    });



    $('.ui.accordion').accordion();

    $('#close_dialy_tip').on('click', function () {
        $(this).closest('#dialy_tip').transition('fade');
    })
    ;

    $('#close_missing_cat').on('click', function () {
        $(this).closest('#missing_cat_row').transition('fade');
    })
    ;


    $("#service-dropdown").dropdown({
        allowLabels: true,
    });

    $(".service-dropdown").dropdown({
        allowLabels: true,
    });

    $("#service-dropdown2").dropdown({
        allowLabels: true
    });

    $('.ui.checkbox')
  .checkbox()
    ;

    $('.coupled.modal')
  .modal({
      allowMultiple: true
  })
    ;

    $('#coat')
    .popup({
        inline: true,
        hoverable: true,
        position: 'top left',
        delay: {
            show: 300,
            hide: 200
        }
    })
    ;

    $('.special.cards .image').dimmer({
        on: 'hover'
    });

    $('.ui.sticky')
      .sticky({
          context: '#example1'
      });

    $('.pointing.menu .item').tab();

    $('.myforum').on('click', function () {
        $('.ui .item').removeClass('active');
        $(this).addClass('active');
    });



    $('#click1').click(function () {
        $('.shape').shape('flip back');
    });

    $('.ui.sidebar').sidebar({
    });


    $('.special.cards .image').dimmer({
        on: 'hover'
    });



    $("#call_adopt_modal").click(function () {
        $('#adopt_modal')
            .modal('show')
              .modal('setting', 'transition', 'scale');
    });


    $("#call_cat_profile_modal").click(function () {
        $('#create_cat_modal')
                .modal('show')
                .modal({
                    blurring: true
                })
                  .modal('setting', 'transition', 'fade up');
    });

    $("#call_create_chapter").click(function () {
        $('#create_chapter')
                .modal('show')
                .modal({ blurring: true })
                 .modal('setting', 'closable', false)
                  .modal('setting', 'transition', 'fade up');
    });

    $("#close_create_chapter").click(function () {
        $('#create_chapter')
                .modal('hide');
    });


    $("#call_add_diary_owner").click(function () {
        $('#add_diary_owner')
                .modal('show')
                .modal({
                    blurring: true
                })
                  .modal('setting', 'transition', 'fade up');
    });

    $("#coat").click(function () {
        $('#coat_modal')

              .modal('setting', 'transition', 'fade up');

    });



    $("#confirm_adoption").click(function () {
        alertify.set('notifier', 'position', 'top-right');
        alertify.notify('You will get in touch soon', 'success', 5, function () { console.log('dismissed'); });
    });

    $('.DeleteCat_Button').click(function (e) {
        e.preventDefault();
        if (confirm("Do you want to delete this cat from the diary?")) {
            $.post(BaseURL + '/Cats/DeleteCat', {
                ID: $(this).data('id')
            }, function (data) {
                if (data.Result == "Success") {
                    alert("Cat Deleted");
                    window.location.reload();
                } else {
                    alert(data.Result);
                }
            })
        }
    });

    $('.DeleteOwner_Button').click(function (e) {
        e.preventDefault();
        if (confirm("Do you want to delete this cat from the diary?")) {
            $.post(BaseURL + '/Diaries/DeleteOwner', {
                catid: $(this).data('id')
            }, function (data) {
                if (data.Result == "Success") {
                    alert("Cat Deleted");
                    window.location.reload();
                } else {
                    alert(data.Result);
                }
            })
        }
    });

    $('.AddOwner_Button').click(function (e) {
        e.preventDefault();
        if (confirm("Do you want to add this cat to be diary owner?")) {
            $.post(BaseURL + '/Diaries/AddOwner', {
                catid: $(this).data('id')
            }, function (data) {
                if (data.Result == "Success") {
                    alert("Cat add success");
                    window.location.reload();
                } else {
                    alert(data.Result);
                }
            })
        }
    });


    $('.EditDiary_Button').click(function (e) {
        e.preventDefault();
        $.post(BaseURL + '/Diaries/EditDiary', {
            diaryid: $(this).data('id'),
            newName: $('#newName').val(),
            newDescription: $('#newDescription').val(),
        }, function (data) {
            if (data.Result == "Success") {
                window.location.reload();
            } else {
                alert(data.Result);
            }
        })
    }
    );

    $('.DeleteDiary_Button').click(function (e) {
        e.preventDefault();
        if (confirm("Do you want to delete this diary?")) {
            $.post(BaseURL + '/Diaries/DeleteDiary', {
                diaryid: $(this).data('id')
            }, function (data) {
                if (data.Result == "Success") {
                    alert("Diary Deleted");
                    window.location.replace(BaseURL + '/Home/Mydiary')
                } else {
                    alert(data.Result);
                }
            })
        }
    });

    $('.AddFoll_Button').click(function (e) {
        e.preventDefault();
        $.post(BaseURL + '/Diaries/AddFoll', {
            id: $(this).data('id')
        }, function (data) {
            if (data.Result == "Success") {
                window.location.reload();
            } else {
                alert(data.Result);
            }
        })

    });

    $('.UnFoll_Button').click(function (e) {
        e.preventDefault();
        $.post(BaseURL + '/Diaries/UnFoll', {
            id: $(this).data('id')
        }, function (data) {
            if (data.Result == "Success") {
                window.location.reload();
            } else {
                alert(data.Result);
            }
        })

    });

    $('.CreateChapter_Button').click(function (e) {
        e.preventDefault();
        $.post(BaseURL + '/Chapters/CreateChapter', {
            name: $('#name').val(),
            detail: CKEDITOR.instances.editor.getData(),
        }, function (data) {
            if (data.Result == "Success") {
                alert("create chapter success");
                window.location.replace(document.referrer)
            } else {
                alert(data.Result);
            }
        })
    }
    );


    $('.EditChapter_Button').click(function (e) {
        e.preventDefault();
        $.post(BaseURL + '/Chapters/EditChapter', {
            chapterid: $(this).data('id'),
            newName: $('#newName').val(),
            newDetail: CKEDITOR.instances.editor.getData(),
        }, function (data) {
            if (data.Result == "Success") {
                alert("Diary edit success");
                window.location.reload();
            } else {
                alert(data.Result);
            }
        })
    }
    );

    $('.DeleteChapter_Button').click(function (e) {
        e.preventDefault();
        if (confirm("Do you want to delete this cat from the diary?")) {
            $.post(BaseURL + '/Chapters/DeleteChapter', {
                id: $(this).data('id')
            }, function (data) {
                if (data.Result == "Success") {
                    alert("Chapter Deleted");
                    window.location.reload();
                } else {
                    alert(data.Result);
                }
            })
        }
    });


    if ($('#AllActive').data('status') == "1") {
        $('.AllLink').addClass('active');
    }
    if ($('#AdoptionActive').data('status') == "1") {
        $('.AdoptionLink').addClass('active');
    }
    if ($('#DiscussionActive').data('status') == "1") {
        $('.DiscussionLink').addClass('active');
    }
    if ($('#FindownerActive').data('status') == "1") {
        $('.AdoptionLink').addClass('active');
    }
    if ($('#FindownerActive').data('status') == "1") {
        $('.AdoptionLink').addClass('active');
    }
    if ($('#SOSActive').data('status') == "1") {
        $('.SOSLink').addClass('active');
    }

});



$(function () {
    $(":file").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = imageIsLoaded;
            reader.readAsDataURL(this.files[0]);
        }
    });
});

function imageIsLoaded(e) {
    $('#myCat').attr('src', e.target.result);
};


// Start Form Type Selected
$('.ABCD').on('click', function () {
    var button = $(this);
    var typename = button.data('type');
    window.location.href = window.location.origin + "/Home/MyForum/" + typename;
});

// Start Form Type Selected
$('#Topic_Type').on('change', function () {
    var e = document.getElementById('Topic_Type');
    var id = e.options[e.selectedIndex].value;
    window.location.href = window.location.origin + "/Forums/Create/" + id;
});

