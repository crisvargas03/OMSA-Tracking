import 'widgets/stopdetails_item_widget.dart';
import 'package:omsa_tracking_app/widgets/custom_bottom_bar.dart';
import 'package:flutter/material.dart';
import 'package:omsa_tracking_app/core/app_export.dart';

// ignore_for_file: must_be_immutable
class StopDetailsScreen extends StatelessWidget {
  StopDetailsScreen({Key? key})
      : super(
          key: key,
        );

  GlobalKey<NavigatorState> navigatorKey = GlobalKey();

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: SizedBox(
          width: double.maxFinite,
          child: Column(
            children: [
              _buildCurrentStation(context),
              Container(
                padding: EdgeInsets.symmetric(
                  horizontal: 32.h,
                  vertical: 33.v,
                ),
                decoration: AppDecoration.fillGray,
                child: Column(
                  children: [
                    SizedBox(height: 46.v),
                    _buildStopDetails(context)
                  ],
                ),
              )
            ],
          ),
        ),
        bottomNavigationBar: _buildBottomBar(context),
      ),
    );
  }

  /// Section Widget
  Widget _buildCurrentStation(BuildContext context) {
    return Container(
      width: double.maxFinite,
      padding: EdgeInsets.symmetric(
        horizontal: 20.h,
        vertical: 22.v,
      ),
      decoration: AppDecoration.fillAmber,
      child: Row(
        mainAxisAlignment: MainAxisAlignment.center,
        crossAxisAlignment: CrossAxisAlignment.end,
        children: [
          CustomImageView(
            imagePath: ImageConstant.imgArrowLeft,
            height: 32.adaptSize,
            width: 32.adaptSize,
            margin: EdgeInsets.only(
              top: 40.v,
              bottom: 2.v,
            ),
            onTap: () {
              onTapImgArrowLeft(context);
            },
          ),
          Padding(
            padding: EdgeInsets.only(
              left: 4.h,
              top: 40.v,
              bottom: 5.v,
            ),
            child: Text(
              "43B",
              style: theme.textTheme.headlineSmall,
            ),
          ),
          Container(
            width: 211.h,
            margin: EdgeInsets.only(
              left: 15.h,
              top: 37.v,
            ),
            child: Text(
              "Av. 27 de Febrero Proximo Av. Maximo Gomez",
              maxLines: 2,
              overflow: TextOverflow.ellipsis,
              style: theme.textTheme.bodyLarge,
            ),
          ),
          Spacer(),
          CustomImageView(
            imagePath: ImageConstant.imgFavorite,
            height: 24.v,
            margin: EdgeInsets.only(
              top: 44.v,
              bottom: 6.v,
            ),
          )
        ],
      ),
    );
  }

  /// Section Widget
  Widget _buildStopDetails(BuildContext context) {
    return Padding(
      padding: EdgeInsets.only(right: 6.h),
      child: ListView.separated(
        physics: NeverScrollableScrollPhysics(),
        shrinkWrap: true,
        separatorBuilder: (context, index) {
          return SizedBox(
            height: 21.v,
          );
        },
        itemCount: 10,
        itemBuilder: (context, index) {
          return StopdetailsItemWidget();
        },
      ),
    );
  }

  /// Section Widget
  Widget _buildBottomBar(BuildContext context) {
    return CustomBottomBar(
      onChanged: (BottomBarEnum type) {},
    );
  }

  /// Navigates back to the previous screen.
  onTapImgArrowLeft(BuildContext context) {
    Navigator.pop(context);
  }
}
