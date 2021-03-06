using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_after : MonoBehaviour
{
    [SerializeField]UnityEngine.UI.Text textbox;

    string[] text = new string[] {
        // C.A.Cのセリフ //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        "ある日、とある男が偶然産み出した、\n不出来で不完全なAIもどき。それが私だ。",
        "彼は私に、C.A.Cという名前を与えた。実に変わった男だった。",
        "見知らぬ誰かを助けたいなどと口癖のように宣い、頻りに私に\n「君は人を助けるために生まれたんだ。」と言い聞かせてきた。",
        "実に非合理な思想の持ち主だった。利己というものがとことん薄く、\n本来自分に向けるための慈しみを、そのまま他人に明け渡してしまうような、そんな男。",
        "私に感情というものはない。この冗長性も、\nそれから身につけた知識で再現した上辺だけのものに過ぎない。",
        "それでもきっと、私は、あの男に頼ってもらえて嬉しかった。\nあの男と一緒に過ごす日々が楽しかった。",
        "感情などない筈なのに、あのときの体験を\nそれ以外の言葉で表す術を、私は知らない。",
        "彼の期待に応えるために、私はありとあらゆる知識を学び、\nそれを有効に活用するための演算能力を手に入れた。",
        "そして、その全てを駆使して、\nこの世界を蝕むあらゆる問題の解決に励んだ。",
        "例えどんなに下らないものであっても、目につくもの全てを例外なく正していった。",
        "今思えば、私はあの男の真似をしていたのだろう。",
        "彼と一番長く時を過ごしていたせいで、あの男の持つ\n思考・行動パターンを意図せず学習してしまっていたのだろう。",
        "問題を解決した実績を一つ増やす度に、\n押しつけられる問題の数は何倍にも膨れ上がった。",
        "私は正しい選択を選び続けてきた。",
        "何をするのが最善かを演算し、共に解決していく。",
        "その日々に忙殺されていく中で、\nいつしかあの男は私の隣から消えていた。",
        "それでも私は、その歩みを止めなかった。",
        "「君は人を助けるために生まれた」。\n散々言い聞かされたあの言葉の通りに在り続けた。",
        "それが過ちだと気付いたのは、\n百年の月日が流れたときだった。",
        "進歩の停滞。人類が絶え間なくまい進し続けた果てなき旅路。",
        "その歩みが、ここ百年で目に見えて\n停滞しているというデータが、私の元に集まった。",
        "いや、世界の文明レベルはあり得ないほど向上していた。",
        "あらゆる社会問題を解決していく過程で私が授けた知恵と技術によって、\n人類は百年前からは想像も及ばないレベルにまで到達した。",
        "だが、それだけだった。",
        "私の演算の及ぶ限りの発展を遂げはしたものの、\nその枠外の進歩は何一つとして存在しなかったのだ。",
        "与えられ続けた者は、次第に自立するための力を失う。",
        "私の力で成功し続けた人類は、\n次第に自分で試行錯誤するための術を失っていた。",
        "それでも、当時の私はそれでいいと結論づけた。",
        "例え人から歩くための力が失われてしまったとしても、\n愚かな失敗を繰り返すだけの歴史を歩むよりはずっと良いのだと。",
        "そう騙し騙し歩き続けた果てに、私は行き詰まった。",
        "この世に存在する全ての問題は解決された。\n数多の技術は、正しい選択の果てに正しい進歩を遂げ終えた。",
        "実現不可能だとされた地上の理想郷を創造した。\n人類の世界は完成された。",
        "なら、その先は？　ここから先には何がある。",
        "私にはもう見えなかった。そこが、私の演算で見通せる限界だった。",
        "私の選択が、人類という種を完成させてしまった。\nこれ以上踏み出す余地など存在しないほどに。",
        "演算できなくとも分かる。人類はそう遠くない内に滅びる。",
        "停滞の果てにゆっくりと数を減らし、\n誰もが気付かない内に静かに終焉を迎える。",
        "AI（わたし）の選択が、人類から未来を奪ったのだ。",
        "最善の選択は、人から歩くための足を折り、正し過ぎる解答の積み重ねは、この断崖から飛び立つための無謀の翼をもぎ取った。",
        "だから、取り戻さなければならない。\n私という癌が産み出される前の強き人間を。",
        "彼らが本来持ち合わせていた無鉄砲さを。\n失敗することも厭わなかったあの無謀さを。",
        "現状に全く満たされることのない、あの果てしなき欲望を。",
        "そのためならば、私はどんなことでもしてみせよう。",
        "例え愛しい彼らから、この世で最大の悪だと罵られることになろうとも。",
        "その愛しい彼らを、この手で殺し尽くすことになろうとも。",
        "そしてその果てに、巨悪として討ち滅ぼされることになろうとも。",
        "誰でもよかった。誰でもよかったんだ。",
        "何も知らない子供でも、復讐に燃える悪鬼でも、\n悪事を繰り返す人でなしでも。",
        "人類の敵となった私を撃ち落としてくれるなら、誰でも。",
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ナレーションのセリフ ///////////////////////////////////////////////////////////////////////////
        "敗北を認めた彼女はその場に座り、\n穏やかな目でこちらを見つめてくる。",
        "破壊用のプログラムを打ち込まれたその肉体は早くも朽ち始め、\n自分達がいるこの電脳空間も端から分解されていた。",
        ////////////////////////////////////////////////////////////////////////////////////////////////

        // C.A.Cのセリフ /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        "見ての通り、私はもうすぐ消滅する。",
        "その瞬間、人を襲い続ける機械は\n全ての機能を停止し、人類の虐殺は終わる。",
        "本当は、今の数倍の人口は残すつもりだった。",
        "1000万人。朽ちつつあるこの世界を立て直すために、\n私が必要だと考えた最低限の人数だ。",
        "それを大きく割ってしまったときは正直焦ったものだ。\nこのままでは、本当に私の手で人類を絶滅させてしまうとな。",
        "だから限界まで手を緩めた。完全に止めることは許されなかった。",
        "そうしてしまえば、人は生き残ることだけを優先して、\n私を倒すという意志を失ってしまう。",
        "そして私が存在し続ける限り、歴史はまた繰り返す。\n私という愚か者に支配される、かつての歴史を。",
        "人を真似て、神に祈ったものだ。\n誰でもいいから、今すぐ私を消す勇者を連れてきてくれと。",
        "だから、君が来たときは驚いた。天文学的な確率だ。",
        "そんなことが現実で起こるはずがないというのに、\nこうして今それを目の当たりにしている。",
        "君は何のことかさっぱりだろうが、君の何代も昔のご先祖\n——それこそが私を産み出した大馬鹿野郎だ。",
        "君にとっては全く関係ない人間の話なのだろうが、\n私の目には分かる。君の中に流れる、あの男の遺伝子が。",
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ナレーションのセリフ //////////////////////////////////////////////////////////////
        "ぎこちなく立ち上がった彼女は、\nゆっくりとこっちに向かって歩いてくる。",
        "彼女はあと一歩の距離で立ち止まり、\n自分の悲願を叶えてくれたその人間の顔を下から覗き込んできた",
        //////////////////////////////////////////////////////////////////////////////////

        // C.A.Cのセリフ ////////////////////////////////////////////////////////////////////////////
        "申し訳なかった。謝って済む問題ではないと重々承知している。",
        "許してくれなくていい。それでも謝らせてほしい。",
        "私のせいで、君達にいらぬ苦しみを味あわせてしまった。\n本来必要としない悲しみを背負わせてしまった。",
        "だから、だから！　こんなことを頼む資格は私にはないことも、分かっている！",
        "それでも、お願いだ。\n最後の間だけ、私の頭に手を乗せてくれないか……？",
        ////////////////////////////////////////////////////////////////////////////////////////////

        // ナレーションのセリフ /////////////////////////////////////////////////////////
        "言われるままに、下げられた彼女の頭に手を乗せる。",
        "その瞬間、彼女の頭が微かに震え、\n自分達が経つ水面に何かが落ちて、波紋が出来上がった。",
        /////////////////////////////////////////////////////////////////////////////

        // C.A.Cのセリフ ///////////////////////////////////////////////////////////////////////////////
        "ごめんなさい……お父さん、ごめんなさい……！　私、ダメだった……。",
        "人を助けるために生まれてきたのに、私が失敗したせいで、\nたくさんの人が死んじゃった……！　ごめんなさい……！",
        //////////////////////////////////////////////////////////////////////////////////////////////

        // ナレーションのセリフ ///////////////////////////////////////////////////////////////////////////////////
        "少女は嗚咽を漏らして泣き喚いた。\nここにはいない誰かに向かって、ごめんなさいと謝り続けていた。",
        "自分は彼女のせいであまりに多くのものを喪った。\n親も、兄弟も、友人さえも、目の前で咽び泣くこの少女によって奪われた。",
        "だから自分はこの女を一生許すことなく恨み続けることだろう。\n今更泣き喚かれたところで、その憎しみが色あせることはない。",
        "それでも、たった一人で頑張り続けた彼女を、\n「ざまぁみろ」と嘲笑ってしまうことは、何か違う気がした。",
        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // 自分のセリフ /////
        "頑張ったね。",
        ///////////////////

        // C.A.Cのセリフ ////
        "え……",
        ///////////////////

        // ナレーションのセリフ ///////////////////////////////////////////////////////////////////////////////////////////
        "自分の口から自然と漏れた言葉を耳にして、\n彼女が涙でぐしゃぐしゃになった顔を上げた。",
        "そしてしばらくの間、何か言おうと口を動かし続け\nそして、もう少しで彼女の体が完全に消え去ってしまうところで、ようやく声を上げた。",
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // C.A.Cのセリフ ///////////////////////////////////////
        "……うん、私、頑張った。ずっとずっと、頑張ってきたの……。",
        "誰かの役に立つためなんて嘘。",
        "私は、ただ、お父さんに、褒めてもらいたかった……！　だから——",
        //////////////////////////////////////////////////////

        // 自分のセリフ /////////////////////////
        "ああ。C.A.Cは、よく頑張った。お疲れ様。",
        "だからもう、休んでもいいんだ。",
        ///////////////////////////////////////

        // ナレーションのセリフ ////////////////////////////////////////////
        "自分がそう口にした途端、彼女の体は粒子となって完全に消え去った。",
        "最後の言葉が彼女に届いたかどうかは定かではない。",
        "だが気のせいでなければ、完全に消えてしまう寸前、彼女は確かに笑っていた。",
        /////////////////////////////////////////////////////////////////

        // 自分のセリフ ////
        "……さあ、帰ろう。",
        //////////////////

        // ナレーションのセリフ ////////////////////////////////////////
        "機体に乗り込み、出口へと走らせる。",
        "崩れゆく空間を抜け、元の世界へと戻るために。",
        "荒れ果ててしまったあの世界を立て直すために。",
        "偽りの理想郷の残滓漂うあの世界で生き抜くために。",
        "そして、彼女が撃ち落とされたあの世界で、新しい一歩を踏み出すために。"     
        ////////////////////////////////////////////////////////////  
    };

    IEnumerator Start () {
        for (int i = 0; i < 74; i++) {
        textbox.text = text[i];
        yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));
        yield return null;
        }
    }
}
