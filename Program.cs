using IdleGameThread;

Game jogo = new Game();

var click = new Action(jogo.Click);
var farm = new Action(jogo.Farm);
var hud = new Action(jogo.Hud);

Parallel.Invoke(click, farm, hud);