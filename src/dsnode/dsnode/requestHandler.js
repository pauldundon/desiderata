function RequestHandler() {
    return {
        dispatch: function (req, res) {
            res.writeHead(200, {
                "Access-Control-Allow-Origin": "*"});
            try {
                this.processRequest(req, res);
            } catch (e) {
                res.writeHead(404);
                res.end('Not Found\n');
            }
        },

        processRequest: function (req, res) {
            res.writeHead(200, { 'Content-Type': 'text/plain' });
            res.end('Handler not called\n');
        }
    }
}


module.exports.RequestHandler = RequestHandler;
