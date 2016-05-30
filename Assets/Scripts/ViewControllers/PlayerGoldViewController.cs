using UnityEngine.UI;

public interface IPlayerGoldViewController : IViewController {

}

public class PlayerGoldViewController : ViewController, IPlayerGoldViewController {

    public Text GoldAmount;

    public override void UpdateContent()
    {
        GoldAmount.text = gameObject.GetEntityLink().entity.money.Amount.ToString();
    }
}
