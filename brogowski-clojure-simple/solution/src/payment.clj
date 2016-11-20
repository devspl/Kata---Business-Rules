(ns solution.payment)

(defn product-has-type?
  [product type]
  (let [types (:types product)]
    (some #{type} types)))

(defn substract
  "Removes collection elements from other collection"
  [pred-coll coll]
  (remove #(some #{%} pred-coll) coll))

(defn product-has-any-type?
  [product expected-types]
  (let [product-types (:types product)]
    (< (count (substract product-types expected-types))
       (count expected-types))))

(defn build-payment-rule
  [activation-check activator]
  {:activation-check (fn [product] (activation-check product))
   :activator        (fn [product] (activator product))})

(defn generate-packing-slip-stub
  "Stub function for packaging slip generation/save/send."
  [product](println (str "Packaging slip for: " product)))

(defn generate-duplicate-packaging-slip-stub
  "Stub function for duplicate packaging slip generation/save/send."
  [product](println (str "Duplicate packaging slip for: " product)))

(defn activate-membership-stub
  "Stub function for activating membership"
  [product](println (str "Activating membership for: " product)))

(defn upgrade-membership-stub
  "Stub function for upgrading membership"
  [product](println (str "Upgrading membership for: " product)))

(defn email-about-activation-or-upgrade-stub
  "Stub function for sending email about membership upgrade/activation"
  [product](println (str "Notifing about membership upgrade/activation for: " product)))

(def payment-rules
  (list (build-payment-rule #(product-has-type? % :physical)
                            #(generate-packing-slip-stub %))
        (build-payment-rule #(product-has-type? % :book)
                            #(generate-duplicate-packaging-slip-stub %))
        (build-payment-rule #(product-has-type? % :membership)
                            #(activate-membership-stub %))
        (build-payment-rule #(product-has-type? % :membership-upgrade)
                            #(upgrade-membership-stub %))
        (build-payment-rule #(product-has-any-type? % (list :membership :membership-upgrade))
                            #(email-about-activation-or-upgrade-stub %))))

(defn execute-rule-if-applies
  [product rule]
  (let [rule-applies? (:activation-check rule)
        execute-rule (:activator rule)]
    (when (rule-applies? product)
      (execute-rule product))))

(defn recieve-payment
  "Handles new payment"
  ([payment]
    (recieve-payment payment payment-rules))
  ([payment rules]
    (let [product (:product payment)]
      (doall (map #(execute-rule-if-applies product %) rules)))))