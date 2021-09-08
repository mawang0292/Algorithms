using System;
using System.Collections.Generic;

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

        /// <summary>
        /// * <문제> N명의 모험가
        /// * 한 마을에 모험가가 N명 있습니다. 모험가 길드에서는 N명의 모험가를 대상으로 '공포도'를 측정했는데,
        /// * '공포도'가 높은 모험가는 쉽게 공포를 느껴 위험 상황에서 제대로 대처할 능력이 떨어집니다.
        /// * 모험가 길드장인 길드마스터는 모험가 그룹을 안전하게 구성하고자 공포도가 X인 모험가는 반드시 X명 이상으로
        /// * 구성한 모험가 그룹에 참여해야 여행을 떠날 수 있도록 규정했습니다.
        /// * 길드마스터는 최대 몇 개의 모험가 그룹을 만들 수 있는지 궁금합니다. N명의 모험가에 대한 정보가 주어졌을때,
        /// * 여행을 떠날 수 있는 그룹 수의 최댓값을 구하는 프로그램을 작성하세요
        /// </summary>
        public static void NAdventurers()
        {
            //* 문제 데이터 입력 부분
            int n = 0;
            Console.Write("모험가 인원수 를 입력해주세요 : ");
            n = Int32.Parse(Console.ReadLine());

            string str = null;
            string[] token;
            List<int> array = new List<int>();

            Console.Write(n + "명의 모험가에게 공포도를 넣어주세요 : ");
            str = Console.ReadLine();
            token = str.Split(' ');
            if (token.Length != n)
            {
                Console.WriteLine("공포도 잘못입력했습니다.");
                return;
            }
            for (int i = 0; i < n; i++)
            {
                array.Add(Convert.ToInt32(token[i]));
            }


            Console.Write("모험가 공포도 : ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
            }


            //* 총 그룹의 수
            int result = 0;
            //* 현재 그룹에 포함된 모험가 수
            int count = 0;

            //* 모험가의 공포도를 정렬시킨다.
            array.Sort();

            Console.WriteLine();
            Console.Write("모험가 공포도 : ");

            for (int i = 0; i < array.Count; i++)
            {
                //* 그룹에 모험가를 1명씩 포함시킨다.
                count += 1;
                //* 그룹의 모험가 수가 공포도 와 같거나 크면 파티를 결성한다.
                if (count >= array[i]) 
                {
                    //* 그룹수를 추가한다.
                    result += 1;
                    //* 그룹에 포함된 모험가수를 초기화한다.
                    count = 0;
                }
            }
            Console.WriteLine("결성된 그룹의 수 : " + result);
        }


    }

}