using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using GoToSleep.Manager;

namespace GoToSleep.UI
{
    public class LoadingScene : MonoBehaviour
    {
        [SerializeField] private Image background;

        [SerializeField] private TextMeshProUGUI text;

        private RectTransform rectTr;

        public float speed;

        private int index;


        private void Awake()
        {
            gameObject.SetActive(false);
            rectTr = background.rectTransform;
        }

        private void Start()
        {
            UiManager.Instance.loading = this;
        }


        public void LoadScene(int sceneIndex)
        {
            index = sceneIndex;
            gameObject.SetActive(true);
            StartCoroutine(HorizontalMove(0));
        }

        public IEnumerator HorizontalMove(int value)
        {
            yield return null;
            float setX = value == 1 ? -2000 : 2000;
            float dirX = value == 1 ? 2000 : -2000;
            rectTr.localPosition = new Vector3(setX, 0, 0);
            Vector2 dirVec = Vector2.zero;
            bool isOnce = false;
            while (true)
            {
                yield return null;
                rectTr.localPosition = Vector2.MoveTowards(rectTr.localPosition, dirVec, speed * Time.deltaTime);
                if (Vector2.Distance(rectTr.localPosition, Vector2.zero) <= 10 && !isOnce)
                {
                    AsyncOperation op = SceneManager.LoadSceneAsync(index);
                    op.allowSceneActivation = false;
                    while (!op.isDone)
                    {
                        yield return null;
                        if (op.progress >= 0.9f)
                        {
                            op.allowSceneActivation = true;
                        }
                    }
                    text.gameObject.SetActive(true);
                    Time.timeScale = 0;
                    while (true)
                    {
                        yield return null;
                        if (Input.GetMouseButtonDown(0))
                        {
                            Time.timeScale = 1;
                            dirVec = new Vector2(dirX, 0);
                            text.gameObject.SetActive(false);
                            isOnce = true;
                            break;
                        }
                    }
                }
                if (Vector2.Distance(rectTr.localPosition, dirVec) < 10)
                {
                    gameObject.SetActive(false);
                    break;
                }
            }
        }
    }
}
