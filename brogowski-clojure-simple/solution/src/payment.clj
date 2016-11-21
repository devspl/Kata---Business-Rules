(ns solution.payment)

(defn product-has-type?
  [product type]
  (let [types (:types product)]
    (some #{type} types)))

(defn substract
  "Removes collection elements from other collection"
  [pred-coll coll]
  (remove #(some #{%} pred-coll) coll))

(defn product-has-title?
  [product expected-title]
  (let [title (:title product)]
    (= title expected-title)))

(defn product-has-any-type?
  [product expected-types]
  (let [product-types (:types product)]
    (< (count (substract product-types expected-types))
       (count expected-types))))

(defn execute-action-rule-if-applies
  [product rule]
  (let [rule-applies? (:activation-check rule)
        execute-rule (:activator rule)]
    (when (rule-applies? product)
      (execute-rule product))))

(defn execute-chain-rule-if-applies
  [product previous-result rule]
  (let [rule-applies? (:activation-check rule)
        execute-rule (:activator rule)]
    (if (rule-applies? product)
      (execute-rule product previous-result)
      previous-result)))

(defn build-chained-rule
  [activation-check activator]
  {:activation-check (fn [product] (activation-check product))
   :activator        (fn [product previous-result] (activator product previous-result))})

(defn build-action-rule
  [activation-check activator]
  {:activation-check (fn [product] (activation-check product))
   :activator        (fn [product] (activator product))})

(defn build-chained-rules
  "Sequentialy executes applicable rules and passes result along."
  [& chained-rules]
  {:activation-check (constantly true)
   :activator        (fn [product]
                       (loop [remaining-rules chained-rules
                              rule-result {}]
                         (if-not (empty? remaining-rules)
                           (let [[rule & rest] remaining-rules]
                             (recur rest (execute-chain-rule-if-applies product
                                                                        rule-result
                                                                        rule))))))})

(defn generate-packing-slip
  "Stub function for packaging slip generation/save/send."
  [product] (do
              (println (str "Packaging slip for: " product))
              {:products (list product)}))

(defn generate-duplicate-packaging-slip
  "Stub function for duplicate packaging slip generation/save/send."
  [packaging-slip] (do
                             (println (str "Duplicate packaging slip for: " packaging-slip))
                             packaging-slip))

(defn add-first-aid-movie-to-packaging-slip
  "Stub function for adding first aid movie to packagin slip"
  [packaging-slip]
  (let [products (:products packaging-slip)]
    (let [new-packaging-slip (assoc packaging-slip :products
                                                   (conj products {:types [:movie :physical]
                                                                   :title "First Aid"}))]
      (do (println (str "Added movie to: " new-packaging-slip))
          new-packaging-slip))))

(defn activate-membership
  "Stub function for activating membership"
  [product] (println (str "Activating membership for: " product)))

(defn upgrade-membership
  "Stub function for upgrading membership"
  [product] (println (str "Upgrading membership for: " product)))

(defn email-about-activation-or-upgrade
  "Stub function for sending email about membership upgrade/activation"
  [product] (println (str "Notifing about membership upgrade/activation for: " product)))

(def payment-rules
  (list (build-chained-rules (build-chained-rule #(product-has-type? % :physical)
                                                 (fn [product & _] (generate-packing-slip product)))
                             (build-chained-rule #(and (product-has-type? % :movie)
                                                       (product-has-title? % "Learning to Ski"))
                                                 (fn [_ packaging-slip] (add-first-aid-movie-to-packaging-slip packaging-slip)))
                             (build-chained-rule #(product-has-type? % :book)
                                                 (fn [_ packaging-slip] (generate-duplicate-packaging-slip packaging-slip))))
        (build-action-rule #(product-has-type? % :membership)
                           #(activate-membership %))
        (build-action-rule #(product-has-type? % :membership-upgrade)
                           #(upgrade-membership %))
        (build-action-rule #(product-has-any-type? % (list :membership :membership-upgrade))
                           #(email-about-activation-or-upgrade %))))

(defn recieve-payment
  "Handles new payment"
  ([payment]
   (recieve-payment payment payment-rules))
  ([payment rules]
   (let [product (:product payment)]
     (doall (map #(execute-action-rule-if-applies product %) rules)))))