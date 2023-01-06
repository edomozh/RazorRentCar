"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/asker").build();

connection.on("NewAskReceived", function (msg) {
    alert(msg)
});

connection.start().catch(function (err) { return console.error(err.toString()); });