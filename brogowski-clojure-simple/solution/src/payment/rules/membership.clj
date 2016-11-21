(ns payment.rules.membership)
(use 'payment.rules.utils 'payment.utils)

(defn activate-membership
  "Stub function for activating membership"
  [product] (println (str "Activating membership for: " product)))

(defn upgrade-membership
  "Stub function for upgrading membership"
  [product] (println (str "Upgrading membership for: " product)))

(defn email-about-activation-or-upgrade
  "Stub function for sending email about membership upgrade/activation"
  [product] (println (str "Notifing about membership upgrade/activation for: " product)))

(def membership-payment-rules
  (list (build-action-rule #(product-has-type? % :membership)
                           #(activate-membership %))
        (build-action-rule #(product-has-type? % :membership-upgrade)
                           #(upgrade-membership %))
        (build-action-rule #(product-has-any-type? % (list :membership :membership-upgrade))
                           #(email-about-activation-or-upgrade %))))