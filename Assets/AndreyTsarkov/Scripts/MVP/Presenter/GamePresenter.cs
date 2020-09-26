using System.Collections;
using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    [SerializeField]
    private TextAsset _data;
    [SerializeField]
    private GameModelValue _model;

    IEnumerator Start()
    {
        /*
         * Ждем кадр, чтобы все успели подписаться. Обычно я использую реактивные расширения и там ждать не надо,
         * но для простоты и наглядности делаю без них, поэтому ждем кадр. Можно было бы и без RX не ждать, но
         * пришлось бы писать очень много бойлерплейт кода.
         */
        yield return null;
        _model.Initialize(_data);
    }
}
