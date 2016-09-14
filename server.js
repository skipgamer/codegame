var io = require('socket.io')(process.env.port || 3000);
var shortid = require('shortid');



console.log('server started');


io.on('connection', function(socket) {
    
    var clientID = shortid.generate();
    
    console.log('received client connection, id:', clientID);
    //return unique id back to client
    socket.emit('connected', {id: clientID});
    
    socket.on('ping', function(){
        console.log('received ping request from id:', clientID);
        socket.emit('pong');
    })
    
    socket.on('spawnplayer', function(){
        
        console.log('received spawn message')
        
        //send spawn message to all clients
        socket.broadcast.emit('spawn');
    })
    
    socket.on('disconnect', function(){
        
        console.log('client disconnected, id:', clientID)
        
    })
})