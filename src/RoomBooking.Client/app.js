'use strict';
var app = require('electron').app;
var browser = require('electron').BrowserWindow;
var client = require('electron-connect').client;

app.on('ready', function () {

    var mainWindow = new browser({
        width: 800,
        height: 600
    });

    mainWindow.loadURL('file://' + __dirname + '/index.html');

    client.create(mainWindow);
});