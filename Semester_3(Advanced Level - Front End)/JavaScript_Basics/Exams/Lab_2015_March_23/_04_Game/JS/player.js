/**
 * Created by toshiba on 23.3.2015 г..
 */
var Player = (function(){
    function Player(x, y, rowClip) {
        this.position = new Vector2(x, y);
        this.movement = {left: false, right : false};
        this.velocity = 15;
        this.width = 128;
        this.height = 48;
        this.scores = 0;

        this.animation = new Animation( this.width, this.height, rowClip, 0, 1, 'resources/paddles.PNG', 1, 2, 1);
        this.boundingBox = new Rectangle ( x+1, y+1, this.width-1, this.height-1)
    }

    Player.prototype.update = function() {
        if(this.movement.right) {
            if(this.position.x + this.velocity <= canvas.width - this.width) {
                this.position.x += this.velocity;
            }

        } else if(this.movement.left) {
            if(this.position.x - this.velocity > 0) {
                this.position.x -= this.velocity;
            }
        }
        this.animation.position.set(this.position.x, this.position.y);
        this.boundingBox.x = this.position.x;
        this.boundingBox.y = this.position.y;
        this.animation.update();
    };

    Player.prototype.render = function(ctx) {
        this.animation.draw(ctx);
    };

    return Player;
}());
