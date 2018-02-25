'use strict';
var http = require('http');
var port = process.env.PORT || 1337;
var getHandler = require('./getHandler.js');

http.createServer(function (req, res) {
    var handler = getHandler.GETHandler();
    handler.dispatch(req, res);
}).listen(port);
