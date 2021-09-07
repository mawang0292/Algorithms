using System;


namespace Algorithms.Problem.Greed
{
    public class Greed
    {
        /// <summary>
        /// 거스름 돈 : 문제 설명
        /// * 당신은 음식점의 계산을 도와주는 점원입니다.
        /// * 카운터에는 거스름돈으로 사용할 500원, 100원, 50원, 10원짜리 동전이 무한이 존재한다고 가정합니다.
        /// * 손님에게 거슬러 주어야 할 돈이 N 원일때 거슬러 주어야 할 동전의 최소 개수를 구하세요.
        /// * 단, 거슬러 줘야 할 돈 N은 항상 10의 배수입니다.
        /// </summary>
        public static int Change(int money)
        {
            //* 음식점에서 거스름돈으로 사용하는 돈의 단위입니다.
            int[] array = new int[] { 500, 100, 50, 10 };
            //* 계산해야할돈
            int n = money;
            //* 동전의 갯수
            int cnt = 0;

            //* 거스름돈으로 사용되는 화폐의 종류 만큼 반복합니다.
            //* 즉 화폐의 종류에만 영향을 받아 반복하기때문에, 시간복잡도는 O(n) 입니다.
            for (int i = 0; i < 4; i++)
            {
                //* 
                cnt += n / array[i];
                n = n % array[i];
            }

            return cnt;
        }

        /// <summary>
        /// * <문제> 1이 될때까지
        /// * 어떠한 수 N 이 1이 될때까지 다음의 두 과정 중 하나를 반복적으로 수행하려고 합니다.
        /// * 단, 두번째 연산은 N이 K로 나누어 떨어질 때만 선택할수있습니다.
        /// * 1. N에서 1을 뺍니다.
        /// * 2. N을 K로 나눕니다.
        /// * 1 이 될때까지의 연산 최소 횟수를 구합니다.
        /// </summary>
        public static int UntilOne_0(int n, int k)
        {
            int cnt = 0;

            if (1 <= n && n <= 1000000)
            {
                if (2 <= k && k <= 1000000)
                {
                    while (n != 1)
                    {
                        if (n % k == 0)
                            n /= k;
                        else
                            n--;

                        cnt++;
                    }
                }
            }
            return cnt;
        }
        //* 위 와 같은 문제
        public static int UntilOne_1(int n, int k)
        {
            int cnt = 0;

            if (1 <= n && n <= 1000000)
            {
                if (2 <= k && k <= 1000000)
                {
                    while (true)
                    {
                        int target = (n / k) * k;
                        cnt += (n - target);
                        n = target;

                        if (n < k)
                            break;

                        cnt++;
                        n /= k;
                    }

                    cnt += (n - 1);
                }
            }
            return cnt;
        }
        //* 위와 같음
        public static int UntilOne_2(int n, int k)
        {
            int cnt = 0;

            if (1 <= n && n <= 1000000)
            {
                if (2 <= k && k <= 1000000)
                {
                    while (true)
                    {
                        int target = (n % k);
                        cnt += (target);

                        n = (n / k) * k;

                        if (n < k)
                            break;

                        cnt++;
                        n /= k;
                    }

                    cnt += (n - 1);
                }
            }
            return cnt;
        }

        /// <summary>
        /// * <문제> 곱하기 혹은 더하기
        /// * 각자리가 숫자 0 부터 9로만 이루어진 문자열 S가 주어졌을때,
        /// * 왼쪽부터 오른쪽으로 하나씩 모든 숫자를 확인하며 숫자 사이에 'x' 혹은 '+' 연산자를 넣어
        /// * 결과적으로 만들어질 수 있는 가장 큰 수를 구하는 프로그램을 작성하세요. 단 + 보다 x를 먼저 계산하는
        /// * 일반적인 방식과는 달리, 모든 연산은 왼쪽에서부터 순서대로 이루어진다고 가정합니다.
        /// * ex 02984 라는 문자열로 만들수있는 가장 큰수는 ((((0+2) x 9 ) x 8) x 4) = 576 입니다.
        /// * 또한 만들어질 수 있는 가장 큰수는 항상 20억 이하의 정수가 되도록 입력이 주어집니다.
        /// </summary>
        public static int MultiplyOrAdd_0(string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int n = int.Parse(s[i].ToString());
                if (result == 0)
                    result = n;
                else if (n == 0 || n == 1)
                    result += n;
                else
                    result *= n;
            }
            return result;
        }
        public static int MultiplyOrAdd_1(string s)
        {
            int result;
            result = Int32.Parse(s[0].ToString());

            for (int i = 1; i < s.Length; i++)
            {
                int n = Int32.Parse(s[i].ToString());
                if (n <= 1 || result <= 1)
                    result += n;
                else
                    result *= n;
            }
            return result;
        }
    }
}