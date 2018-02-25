var RequestHandler=require('./requestHandler');

function GETHandler(req, res) {
    var getHandler = {}
    var x = RequestHandler.RequestHandler();
    getHandler.__proto__ = x;
    getHandler.processRequest = function (req, res) {
        res.writeHead(200, { 'Content-Type': 'text/plain' });
        res.end('GET Handler invoked\n');
    }
    return getHandler;
}

module.exports.GETHandler = GETHandler;
