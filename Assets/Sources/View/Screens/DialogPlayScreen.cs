using System;
using System.Collections;
using Sources.Model;
using Sources.View.Elements.DialogPlay;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.View.Screens
{
    public class DialogPlayScreen : MonoBehaviour
    {
        [SerializeField] private Button _clickArea;

        [SerializeField] private AvatarsView _avatarsView;

        [SerializeField] private ReplicaView _replicaView;

        private bool _clicked;
        
        public bool Playing { get; private set; }

        public event Action End;
        
        private void ScreenClick()
        {
            _clicked = true;
        }

        public void PlayDialog(IDialog dialog)
        {
            if (Playing)
                throw new InvalidOperationException("Already playing");

            _avatarsView.SetDefaultToAll();

            StartCoroutine(PlayingDialog(dialog));
        }

        private void SetReplica(IReplica replica)
        {
            _replicaView.StartPrintingText(replica.Text);
            
            _avatarsView.UpdateActive(replica.AuthorFromRight);
        }

        private void Awake()
        {
            _replicaView.SetCoroutineHelper(this);
        }

        private void Start()
        {
            _clickArea.onClick.AddListener(ScreenClick);
        }

        private IEnumerator PlayingDialog(IDialog dialog)
        {
            Playing = true;

            foreach (var replica in dialog.Replicas)
            {
                SetReplica(replica);

                yield return WaitingClick();

                if (!_replicaView.PrintingNow) 
                    continue;
                
                _replicaView.PushPrinting();

                yield return WaitingClick();
            }

            Playing = false;
            
            End?.Invoke();
        }

        private IEnumerator WaitingClick()
        {
            yield return new WaitUntil(() => _clicked);

            _clicked = false;
        }
    }
}