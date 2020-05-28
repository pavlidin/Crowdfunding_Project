﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function submitProjectToServer() {
    actionMethod = "POST"
    actionUrl = "/Project/CreateProject"
    sendData = {
        "ProjectTitle": $('#ProjectTitle').val(),
        "ProjectDescription": $('#ProjectDescription').val(),
        "ProjectTargetAmount": parseFloat($('#ProjectTargetAmount').val()),
        "ProjectCategory": $('#ProjectCategory').val(),
        "EndingDate": $('#EndingDate').val(),

        //"PledgeTitle": $('#PledgeTitle').val(),
        //"PledgeDescription": $('#PledgeDescription').val(),
        //"PledgePrice": $('#PledgePrice').val(),
        //"PledgeReward": $('#PledgeReward').val(),
    }

    //alert(JSON.stringify(sendData))

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            $('#responseDiv').html(JSON.stringify(data));
            //ProjectId = data["id"]
            alert('You have successfully added a project')
            window.open("/Project/GetMyProjects/ " + "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}

function submitPledgeToServer(projectId) {

    actionMethod = "POST"
    actionUrl = "/Project/CreatePledges/"
    sendData = {
        "ProjectId": projectId,
        "PledgeTitle": $('#PledgeTitle').val(),
        "PledgeDescription": $('#PledgeDescription').val(),
        "PledgePrice": parseFloat($('#PledgePrice').val()),
        "PledgeReward": $('#PledgeReward').val()
    }

    alert(projectId)
    alert(JSON.stringify(sendData))

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            $('#responseDiv').html(JSON.stringify(data));

            alert('You have successfully added a pledge!')
            window.open("/Project/SingleProject?id=" + projectId, "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}

function submitPostToServer(projectId) {
    actionMethod = "POST"
    actionUrl = "/Post/CreatePost"
    sendData = {
        "ProjectId": projectId,
        "PostTitle": $('#PostTitle').val(),
        "PostDescription": $('#PostDescription').val()
    }

    alert(JSON.stringify(sendData))
    //location.reload();

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            //if (data.success == true) { // if true (1)
            //    setTimeout(function () {// wait for 5 secs(2)
            //        location.reload(); // then reload the page.(3)
            //    }, 5000);
            //}

            location.reload();

            //$('#responseDiv').html(JSON.stringify(data));
            //refresh page after the post is added 

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}

function deletePostFromServer(postId) {
    actionMethod = "DELETE"
    actionUrl = "/Post/DeletePost"
    sendData = {
        "ProjectId": projectId,
        "PostTitle": $('#PostTitle').val(),
        "PostDescription": $('#PostDescription').val()
    }

    alert(JSON.stringify(sendData))

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            if (data == null) {
                $('#responseDiv).html("There is no such post');
            }
            //$('#responseDiv').html(JSON.stringify(data));
            //refresh page after the post is added 

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}

function submitBuyPledgeToServer(projectId, pledgeId) {
    actionMethod = "POST"
    actionUrl = "/Project/AddPledge/"
    sendData = {
        "PledgeId": pledgeId,
        "ProjectId": projectId
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,
        success: function(data, textStatus, jQxhr) {
            alert('You have successfully payed for this!')
            window.open("/Project/SingleProject?id=" + projectId, "_self")

            //$('#responseDiv').html(JSON.stringify(data));
            //refresh page after the post is added 

        },
        error: function(jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}

function editProject(projectId) {
    window.open("/Project/EditProject/" + projectId, "_self");
}

function doUpdateProject(projectId) {
    actionMethod = "PUT"
    actionUrl = "/Project/updateproject"
    sendData = {
        "ProjectTitle": $('#ProjectTitle').val(),
        "ProjectDescription": $('#ProjectDescription').val(),
        "ProjectTargetAmount": parseFloat($('#ProjectTargetAmount').val()),
        "IsActive": $('#IsActive').val(),
        "IsComplete": $('#IsComplete').val(),
        "EndingDate": $('#EndingDate').val(),
        "ProjectCategory": $('#ProjectCategory').val(),
        "ProjectId": projectId
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            alert("The project has been successfully updated!");
            

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });


}


function editPledge(pledgeId) {
    window.open("/Project/EditPledge/" + pledgeId, "_self");
}

function doUpdatePledge(pledgeId) {
    actionMethod = "PUT"
    actionUrl = "/Project/updatepledge"
    sendData = {
        "PledgeTitle": $('#PledgeTitle').val(),
        "PledgeDescription": $('#PledgeDescription').val(),
        "PledgePrice": parseFloat($('#PledgePrice').val()),
        "PledgeReward": $('#PledgeReward').val(),
        "PledgeId": pledgeId
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            alert("The pledge has been successfully updated!");

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });


}