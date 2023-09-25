import 'package:adventuraclick_mobile/providers/rating_provider.dart';
import 'package:adventuraclick_mobile/screens/profile_edit_screen.dart';
import 'package:adventuraclick_mobile/utils/auth_helper.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:provider/provider.dart';
import 'package:flutter/material.dart';

class RatingScreen extends StatefulWidget {
  static const String routeName = "/rating";
  String id;
  RatingScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<RatingScreen> createState() => _RatingScreenState();
}

class _RatingScreenState extends State<RatingScreen> {
  late final RatingProvider _ratingProvider;
  final TextEditingController _reviewController = TextEditingController();

  double rating = 0;

  @override
  void initState() {
    super.initState();
    _ratingProvider = context.read<RatingProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: SingleChildScrollView(
          child: Column(children: [
            Container(
              height: 280,
              decoration: const BoxDecoration(
                  image: DecorationImage(
                      image: AssetImage('assets/images/background.jpg'),
                      fit: BoxFit.fill)),
              child: Stack(
                children: [
                  Container(
                    margin: const EdgeInsets.only(top: 280),
                    child: const Center(
                      child: Center(
                          child: Text(
                        "Test",
                        style: TextStyle(
                            color: Colors.cyan,
                            fontSize: 40,
                            fontWeight: FontWeight.bold),
                      )),
                    ),
                  )
                ],
              ),
            ),
            Container(
              margin: const EdgeInsets.only(top: 10),
              child: const Text(
                "Rate the travel",
                style: TextStyle(
                    color: Colors.cyan,
                    fontSize: 30,
                    fontWeight: FontWeight.bold),
              ),
            ),
            const Divider(
              color: Colors.black,
            ),
            const SizedBox(
              height: 30,
            ),
            Center(
                child: RatingBar.builder(
              minRating: 1,
              itemSize: 46,
              itemPadding: const EdgeInsets.symmetric(horizontal: 8),
              maxRating: 5,
              itemBuilder: (context, _) =>
                  const Icon(Icons.star, color: Colors.cyan),
              onRatingUpdate: (double value) {
                rating = value;
              },
            )),
            SizedBox(
              width: 300,
              height: 200,
              child: Card(
                margin: const EdgeInsets.only(top: 40),
                color: Colors.black,
                child: Padding(
                  padding: const EdgeInsets.all(8.0),
                  child: TextField(
                    controller: _reviewController,
                    maxLines: 5, //or null
                    decoration: const InputDecoration.collapsed(
                        hintText: "Enter your review here"),
                  ),
                ),
              ),
            ),
            const SizedBox(
              height: 20,
            ),
            Container(
                height: 50,
                margin: const EdgeInsets.fromLTRB(45, 0, 45, 0),
                decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(10),
                    gradient: const LinearGradient(
                        colors: [Colors.cyan, Colors.red])),
                child: InkWell(
                  onTap: () async {
                    try {
                      await _ratingProvider.insert({
                        'rate': rating.round(),
                        'comment': _reviewController.text,
                        'offerId': 1 /*widget.id*/,
                        'userId': 1 /*Authorization.user!.userId*/,
                      });
                      if(!mounted) return;
                      showDialog(
                          context: context,
                          builder: (BuildContext context) => AlertDialog(
                                title: const Text("Success"),
                                content:
                                    const Text("Rating successfully added!"),
                                actions: [
                                  TextButton(
                                      onPressed: () async =>
                                      // temporary navigation
                                          await Navigator.pushNamed(context,
                                              ProfileScreen.routeName),
                                      child: const Text("Ok"))
                                ],
                              ));
                    } on Exception {
                      showDialog(
                          context: context,
                          builder: (BuildContext context) => AlertDialog(
                                title: const Text("Error"),
                                content: const Text("Check field inputs"),
                                actions: [
                                  TextButton(
                                    child: const Text("Ok"),
                                    onPressed: () => Navigator.pop(context),
                                  )
                                ],
                              ));
                    }
                  },
                  child: const Center(child: Text("Rate")),
                )),
          ]),
        ),
      ),
    );
  }
}