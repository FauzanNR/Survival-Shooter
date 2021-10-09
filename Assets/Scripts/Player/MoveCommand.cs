public class MoveCommand: Command {

	PlayerMovement playerMovement;
	float h, v;

	public MoveCommand(PlayerMovement _playerMovement, float _h, float _v) {
		this.playerMovement = _playerMovement;
		this.h = _h;
		this.v = _v;
	}

	//Trigger perintah movement
	public override void Execute() {
		playerMovement.move( h, v );
		//Menganimasikan player
		playerMovement.animating( h, v );
	}

	public override void UnExecute() {
		//Invers arah dari movement player
		playerMovement.move( -h, -v );
		//Menganimasikan player
		playerMovement.animating( h, v );
	}
}